using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Registration.Data;
using Registration.Entities;

namespace Registration.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var hasSubscription = await _context.Subscriptions.FindAsync(userId);

            if (hasSubscription != null)
            {
                return BadRequest("Already subscribed");
            }

            await _context.Subscriptions.AddAsync(new Subscription
            {
                UserId = userId,
                Type = SubscriptionType.Premium,
                StartedAt = DateTime.Now,
                EndsAt = DateTime.Now.AddDays(7)
            });

            await _context.SaveChangesAsync();

            return Ok("User was subscribed");
        }
    }
}