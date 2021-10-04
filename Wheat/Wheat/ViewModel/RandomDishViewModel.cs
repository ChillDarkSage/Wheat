using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Wheat.Models;

namespace Wheat.ViewModel
{
    public class RandomDishViewModel
    {
        private List<DishModel> dishes;
        public List<DishModel> Dishes => dishes;

        public Random rand;

        public DishViewModel DishViewModel { get; set; }
        public RandomDishViewModel(DishViewModel dishViewModel)
        {
            dishes = new List<DishModel>();
            DishViewModel = dishViewModel;
            Init();
        }

        public void Init()
        {
            rand = new Random();

            //主食.
            var stapleFood = DishViewModel.DishModels.Where(d => !d.IsNonStapleFood).ToList();
            if (stapleFood.Count != 0)
                dishes.Add(stapleFood[rand.Next(0, stapleFood.Count)]);
            //是否需要副食呢.
            if (rand.Next(0, 10) > 4)
            {
                var nonStapleFood = DishViewModel.DishModels.Where(d => d.IsNonStapleFood).ToList();
                if (nonStapleFood.Count != 0)
                    dishes.Add(nonStapleFood[rand.Next(0, nonStapleFood.Count)]);
            }

        }
    }
}
