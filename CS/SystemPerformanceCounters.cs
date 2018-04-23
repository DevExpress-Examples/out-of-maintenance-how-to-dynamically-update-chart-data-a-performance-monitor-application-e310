using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ChartPerfMon
{

    class SystemPerformanceCounters : Object
    {
        private List<PerformanceCounterCategory> performanceCounterCategories;
        private List<PerformanceCounter>[] categoryPerformanceCounters;
        private PerformanceCounterCategory currentCategory;
        private PerformanceCounter currentCounter;

        public PerformanceCounterCategory[] PerformanceCounterCategories
        {
            get { return performanceCounterCategories.ToArray(); }
        }

        public PerformanceCounter[] GetPerformanceCounters(string categoryName)
        {
            for(int i = 0; i < performanceCounterCategories.Count; i++)
                if (performanceCounterCategories[i].CategoryName == categoryName)
                    return categoryPerformanceCounters[i].ToArray();

            throw new Exception("Invalid category name: " + categoryName);
        }

        public string CurrentCategoryName
        {
            get { return currentCategory.CategoryName; }
            set { 
                for(int i = 0; i < performanceCounterCategories.Count; i++)
                    if (performanceCounterCategories[i].CategoryName == value)
                    {
                        currentCategory = performanceCounterCategories[i];
                        return;
                    }

                throw new Exception("Unknown category name: " + value);
            }
        }

        public string CurrentCategoryInstanceName
        {
            get {
                string[] instanceNames = currentCategory.GetInstanceNames();

                if (instanceNames.Length > 0)
                    return instanceNames[0];
                else
                    return "<Noname>";
            }
        }

        public string CurrentCounterName
        {
            get { return currentCounter.CounterName; }
            set
            {
                int catidx = performanceCounterCategories.IndexOf(currentCategory);
                
                for (int i = 0; i < categoryPerformanceCounters[catidx].Count; i++)
                    if (categoryPerformanceCounters[catidx][i].CounterName == value)
                    {
                        currentCounter = categoryPerformanceCounters[catidx][i];
                        return;
                    }

                throw new Exception("Unknown counter name: " + value);
            }
        }
        
        public string CurrentCounterValue
        {
            get { return currentCounter.NextValue().ToString(); }
        }

        public SystemPerformanceCounters()
        :base()
        {
            PerformanceCounterCategory[] categories = PerformanceCounterCategory.GetCategories();

            performanceCounterCategories = new List<PerformanceCounterCategory>(100);

            performanceCounterCategories.AddRange(categories);

            categoryPerformanceCounters = new List<PerformanceCounter>[categories.Length];

            int i = 0;
            
            foreach(PerformanceCounterCategory category in performanceCounterCategories)
            {
                categoryPerformanceCounters[i] = new List<PerformanceCounter>(10);
                
                if (category.CategoryType == PerformanceCounterCategoryType.SingleInstance)
                {
                    categoryPerformanceCounters[i].AddRange(category.GetCounters());
                }
                else 
                {
                    string[] instanceNames = category.GetInstanceNames();

                    if (instanceNames.Length > 0)
                        categoryPerformanceCounters[i].AddRange(category.GetCounters(instanceNames[0]));
                }
                i++;
            }

            currentCategory = performanceCounterCategories[0];
            currentCounter = categoryPerformanceCounters[0][0];
        }

    }
}
