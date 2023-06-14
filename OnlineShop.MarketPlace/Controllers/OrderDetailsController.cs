using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.MarketPlace.Models;
using OnlineShop.MarketPlace.Models.DomainModels.OrderAggregate;
using OnlineShop.Saas.Models.DomainModels.ProductAggregates;

namespace OnlineShop.MarketPlace.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly OnlineShopDbContext _context;

        public OrderDetailsController(OnlineShopDbContext context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            var onlineShopDbContext = _context.OrderDetail.Include(o => o.OrderHeader).Include(o => o.Product);
            return View(await onlineShopDbContext.ToListAsync());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.OrderDetail == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail
                .Include(o => o.OrderHeader)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderHeaderId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderHeaderId"] = new SelectList(_context.OrderHeader, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Id");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderHeaderId,ProductId,UnitPrice,Amount,IsDelete")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderHeaderId"] = new SelectList(_context.OrderHeader, "Id", "Id", orderDetail.OrderHeaderId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Id", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.OrderDetail == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderHeaderId"] = new SelectList(_context.OrderHeader, "Id", "Id", orderDetail.OrderHeaderId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Id", orderDetail.ProductId);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("OrderHeaderId,ProductId,UnitPrice,Amount,IsDelete")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderHeaderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.OrderHeaderId))
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
            ViewData["OrderHeaderId"] = new SelectList(_context.OrderHeader, "Id", "Id", orderDetail.OrderHeaderId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Id", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.OrderDetail == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail
                .Include(o => o.OrderHeader)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderHeaderId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.OrderDetail == null)
            {
                return Problem("Entity set 'OnlineShopDbContext.OrderDetail'  is null.");
            }
            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail != null)
            {
                _context.OrderDetail.Remove(orderDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(Guid? id)
        {
          return (_context.OrderDetail?.Any(e => e.OrderHeaderId == id)).GetValueOrDefault();
        }
    }
}
