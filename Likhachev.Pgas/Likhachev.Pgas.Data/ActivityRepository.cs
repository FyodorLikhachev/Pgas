using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Likhachev.Pgas.Data
{
    using Core.Activities;
    
    public class ActivityRepository : EFRepository<Activity>
    {
        public Activity GetActivity(int id) => _db.Activities
            .Include(a => a.Achievement)
            .Include(a => a.AuthorWork)
            .FirstOrDefault(a => a.Id == id);

        public File GetFileByActivityId(int id) => _db.Files
            .FirstOrDefault(f => f.ActivityId == id);
    }
}
