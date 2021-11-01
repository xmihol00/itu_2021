using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using itu.BL.DTOs.File;
using itu.BL.DTOs.Task;
using itu.BL.DTOs.Task.Interfaces;
using itu.DAL.Entities;
using itu.DAL.Entities.Tasks;

namespace itu.BL.Profiles
{
    public class FileProfiles : Profile
    {
        public FileProfiles()
        {
            CreateMap<FileEntity, AllFileDTO>();

            CreateMap<FileEntity, DownloadFileDTO>()
                .ForMember(dst => dst.Data, opt => opt.MapFrom(src => src.FileData.Data));
        }
    }
}
