using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.MarketPlace.Models;
using OnlineShop.MarketPlace.Models.DomainModels.OrderAggregate;

namespace OnlineShop.MarketPlace.Controllers
{
    public class OrderHeadersController : Controller
    {
        private readonly OnlineShopDbContext _context;

        public OrderHeadersController(OnlineShopDbContext context)
        {
            _context = context;
        }

        // GET: OrderHeaders
        public async Task<IActionResult> Index()
        {
              return _context.OrderHeader != null ? 
                          View(await _context.OrderHeader.ToListAsync()) :
                          Problem("Entity set 'OnlineShopDbContext.OrderHeader'  is null.");
        }

        // GET: OrderHeaders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.OrderHeader == null)
            {
                return NotFound();
            }

            var orderHeader = await _context.OrderHeader
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderHeader == null)
            {
                return NotFound();
            }

            return View(orderHeader);
        }

        // GET: OrderHeaders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SellerRef,BuyerRef,IsDelete")] OrderHeader orderHeader)
        {
            if (ModelState.IsValid)
            {
                orderHeader.Id = Guid.NewGuid();
                _context.Add(orderHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderHeader);
        }

        // GET: OrderHeaders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.OrderHeader == null)
            {
                return NotFound();
            }

            var orderHeader = await _context.OrderHeader.FindAsync(id);
            if (orderHeader == null)
            {
                return NotFound();
            }
            return View(orderHeader);
        }

        // POST: OrderHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SellerRef,BuyerRef,IsDelete")] OrderHeader orderHeader)
        {
            if (id != orderHeader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderHeaderExists(orderHeader.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderHeader);
        }

        // GET: OrderHeaders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.OrderHeader == null)
            {
                return NotFound();
            }

            var orderHeader = await _context.OrderHeader
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderHeader == null)
            {
                return NotFound();
            }

            return View(orderHeader);
        }

        // POST: OrderHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.OrderHeader == null)
            {
                return Problem("Entity set 'OnlineShopDbContext.OrderHeader'  is null.");
            }
            var orderHeader = await _context.OrderHeader.FindAsync(id);
            if (orderHeader != null)
            {
                _context.OrderHeader.Remove(orderHeader);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderHeaderExists(Guid id)
        {
          return (_context.OrderHeader?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
