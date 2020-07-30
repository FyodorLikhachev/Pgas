using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Likhachev.Pgas.Services.Dtos
{
    public enum ActivityTypes
    {
        Achievement = 1,
        AuthorWork
    }
    public class ActivityDto
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public ActivityTypes ActivityType { get; set; }
        public DateTime Date { get; set; }
        public IFormFile PinnedFile { get; set; }
        public int EventLevel { get; set; }
        public int AchievementLevel { get; set; }
        public int GroupSize { get; set; }
        public int CreativeEndeavor { get; set; }
        public string EventLink { get; set; }
    }
}