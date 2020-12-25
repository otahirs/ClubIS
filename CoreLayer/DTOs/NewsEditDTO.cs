﻿using System;

namespace ClubIS.CoreLayer.DTOs
{
    public class NewsEditDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}