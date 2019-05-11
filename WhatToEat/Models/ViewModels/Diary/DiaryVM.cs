﻿namespace WhatToEat.Models.ViewModels.Diary
{
    public class DiaryVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Calorie { get; set; }
        public decimal Total { get { return Quantity * Calorie; } }
        public string Image { get; set; }
    }
}