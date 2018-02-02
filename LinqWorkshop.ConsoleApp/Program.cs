using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqWorkshop.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LazyLoading.LazyLoadItems();

            LazyLoading.EagerLoadWithInclude();

            LazyLoading.EagerLoadingWithLoad();
        }
    }
}
