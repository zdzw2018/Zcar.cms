using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Sample02.Models;

namespace Sample02.Controllers
{
    public class ContentController : Controller
    {
        private readonly Content content;
        public ContentController(IOptionsSnapshot<Content> option)
        {
            content = option.Value;
        }

        public IActionResult Index()
        {
            //var listContent = new List<Content>();
            //for (int i = 0; i < 10; i++)
            //{
            //    listContent.Add(new Content { Id = i, title = $"title{i}", content = $"content{i}", author = $"作者{i}", add_time = DateTime.Now.AddDays(-i) });
            //}
            ContentViewModel ViewModel = new ContentViewModel() { ContentList = new List<Content>() { content } };
            return View(ViewModel);
        }
    }
}