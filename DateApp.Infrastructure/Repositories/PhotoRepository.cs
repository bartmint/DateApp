using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DateApp.Domain.Abstract;
using DateApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.Infrastructure.Repositories
{
    public class PhotoRepository : IPhotoService, IPhotoGet
    {
        private readonly Cloudinary _cloudinary;
        private readonly AppDbContext _ctx;

        
        public PhotoRepository(IOptions<CloudinarySettings> config, AppDbContext ctx)
        {
            var acc = new Account
                (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );//liczy sie porzadek
            _cloudinary = new Cloudinary(acc);
            _ctx = ctx;
        }
        public async  Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }

        public async Task<string> GetPhoto(int id)
        {
            var photo = await _ctx.Photos.Where(x => x.AppUserId == id && x.IsMain).FirstOrDefaultAsync();
            if(photo!=null) return photo.Url;

            return null;
        }
    }
}
