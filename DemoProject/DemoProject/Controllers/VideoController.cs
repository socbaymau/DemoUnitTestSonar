using Data.Models;
using DemoProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }
        //[HttpGet("GetVideoByPath")]
        //public async Task<ActionResult> GetVideoByPath()
        //{

        //    using (var httpClient = new HttpClient())
        //    {
        //        try
        //        {
        //            string host = Environment.GetEnvironmentVariable("VIDEO_STORAGE_HOST");
        //            string port = Environment.GetEnvironmentVariable("VIDEO_STORAGE_PORT");

        //            var res = await httpClient.GetStreamAsync($"http://{host}:{port}/api/video?path=SampleVideo_1280x720_1mb.mp4");
        //            var response = File(res, "video/mp4");
        //            return response;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //    }
        //    return Ok();
        //}

        //[HttpGet("GetVideoById")]
        //public async Task<ActionResult>GetVideoById(int id)
        //{
        //    var video = await _videoService.GetPathById(id);
        //    using (var httpClient = new HttpClient())
        //    {
        //        try
        //        {
        //            string host = Environment.GetEnvironmentVariable("VIDEO_STORAGE_HOST");
        //            string port = Environment.GetEnvironmentVariable("VIDEO_STORAGE_PORT");
        //            var res = await httpClient.GetStreamAsync($"http://{host}:{port}/api/video?path={video.PathName}");
        //            var response = File(res, "video/mp4");
        //            return response;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //    }
        //    return Ok();
        //}
        [HttpGet("GetAll")]
        public ActionResult<List<Videos>>GetAll()
        {
            var data = _videoService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<List<Videos>>> GetAllAsync()
        {
            var data = await _videoService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("GetVideosViewModelAsync")]
        public async Task<ActionResult<List<VideoViewModel>>> GetVideosViewModelAsync()
        {
            var data = await _videoService.GetAllAsync();
            //var model = data.Select(video => new VideoViewModel()
            //{
            //    Id = video.Id,
            //    PathName = video.PathName
            //});
            var list = new List<VideoViewModel>();
            foreach(var item in data)
            {
                var model = new VideoViewModel
                {
                    Id = item.Id,
                    PathName = item.PathName
                };
                list.Add(model);
            }
            return Ok(list);
        }
        [HttpGet("GetVideosViewModel")]
        public ActionResult<List<VideoViewModel>> GetVideosViewModel()
        {
            var data = _videoService.GetAll();
            //var model = data.Select(video => new VideoViewModel()
            //{
            //    Id = video.Id,
            //    PathName = video.PathName
            //});
            var list = new List<VideoViewModel>();
            foreach (var item in data)
            {
                var model = new VideoViewModel
                {
                    Id = item.Id,
                    PathName = item.PathName
                };
                list.Add(model);
            }
            return Ok(list);
        }

    }
}
