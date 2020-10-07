using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.Domain.Abstract
{
    public interface IPhotoGet
    {
        Task<string> GetPhoto(int id);
    }
}
