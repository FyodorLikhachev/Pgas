using System;

namespace Likhachev.Pgas.Services
{
    using Core.Abstractions;
    using Core.Activities;
    using Data;
    using Dtos;

    public class ActivityServices
    {
        #region Private Fields
        private static readonly ActivityRepository _extendedActivityRepository = new ActivityRepository();
        private static readonly IRepository<Activity> _activityRepository = new EFRepository<Activity>();
        private static readonly IRepository<Achievement> _achivementRepository = new EFRepository<Achievement>();
        private static readonly IRepository<AuthorWork> _authorWorkRepository = new EFRepository<AuthorWork>();
        private static readonly IRepository<File> _fileRepository = new EFRepository<File>();
        #endregion

        #region Queries
        public static Activity GetActivity(int id) => _activityRepository.GetById(id);
        public static ActivityDto GetActivityDto(int id)
        {
            var file = _extendedActivityRepository.GetFileByActivityId(id);
            var activity = _activityRepository.GetById(id);
            return new ActivityDto() {
                Id = activity.Id,
                ActivityName = activity.ActivityName,
                Date = activity.Date,
                PinnedFile = file.GetFileStream().ReturnFormFile()
            };
        }
        #endregion

        #region Commands
        public static void AddActivity(ActivityDto activity) 
        {
            // wrap into transaction
            var file = _fileRepository.Create(new File() {
                            FileName = activity.PinnedFile.FileName,
                            FileByte = FileManager.GetByteArrayFromImage(activity.PinnedFile)
                        });

            _activityRepository.Create(new Activity() {
                Id = activity.Id,
                ActivityName = activity.ActivityName,
                Date = activity.Date,
                PinnedFile = file
            });

            if (activity.ActivityType == ActivityTypes.Achievement) AddAchievement(activity);
            else if (activity.ActivityType == ActivityTypes.AuthorWork) AddAuthorWork(activity);
        }
        public static void ModifyActivity(ActivityDto activity)
        {
            var file = new File()
            {
                FileName = activity.PinnedFile.FileName,
                FileByte = FileManager.GetByteArrayFromImage(activity.PinnedFile)
            };
            _fileRepository.Update(file);

            _activityRepository.Update(new Activity()
            {
                Id = activity.Id,
                ActivityName = activity.ActivityName,
                Date = activity.Date,
                PinnedFile = file
            });

            if (activity.ActivityType == ActivityTypes.Achievement) ModifyAchievement(activity);
            else if (activity.ActivityType == ActivityTypes.AuthorWork) ModifyAuthorWork(activity);
        }
        public static void RemoveActivity(int id)
        {
            _activityRepository.Delete(id); // Cascade Delete
        }

        // Private Methods
        private static void AddAchievement(ActivityDto activity)
        {
            _achivementRepository.Create(new Achievement()
            {
                ActivityId = activity.Id,
                EvLvlId = activity.EventLevel,
                AchieveLvlId = activity.AchievementLevel,
                GroupSizeId = activity.GroupSize,
                EventLink = activity.EventLink
            });
        }
        private static void AddAuthorWork(ActivityDto activity) 
        {
            _authorWorkRepository.Create(new AuthorWork() {
                ActivityId = activity.Id,
                CreativeEndeavorId = activity.CreativeEndeavor
            });
        }
        private static void ModifyAchievement(ActivityDto activity)
        {
            _achivementRepository.Update(new Achievement()
            {
                ActivityId = activity.Id,
                EvLvlId = activity.EventLevel,
                AchieveLvlId = activity.AchievementLevel,
                GroupSizeId = activity.GroupSize,
                EventLink = activity.EventLink
            });
        }
        private static void ModifyAuthorWork(ActivityDto activity) 
        {
            _authorWorkRepository.Update(new AuthorWork() {
                ActivityId = activity.Id,
                CreativeEndeavorId = activity.CreativeEndeavor
            });
        }
        #endregion
    }
}
