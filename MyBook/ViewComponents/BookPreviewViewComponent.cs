using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;

namespace MyBook.ViewComponents;

public class BookPreviewViewComponent:ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(Book book)
    {
        return View(book);
    }
}