using Likhachev.Pgas.Core;
using Likhachev.Pgas.Core.Abstractions;
using Likhachev.Pgas.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Likhachev.Pgas.Services
{
    public class ActivityServices
    {
        private static readonly IRepository<Activity> _repository = new EFRepository<Activity>();
        public static string GetName (int id) => _repository.GetById(id).ActivityName;
    }
}
