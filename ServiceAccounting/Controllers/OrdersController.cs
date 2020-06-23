using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServiceAccounting.Data;
using ServiceAccounting.Models;

namespace ServiceAccounting.Controllers
{
    public class OrdersController : Controller
    {
        private ServiceAccountingContext db = new ServiceAccountingContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.client).Include(o => o.service).Include(o => o.worker);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientName");
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "ServiceType");
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName");
            return View();
        }

        // POST: Orders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,WorkerId,ClientId,ServiceId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientName", order.ClientId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "ServiceType", order.ServiceId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", order.WorkerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientName", order.ClientId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "ServiceType", order.ServiceId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", order.WorkerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,WorkerId,ClientId,ServiceId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientName", order.ClientId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "ServiceType", order.ServiceId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", order.WorkerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpPost]
        public ActionResult Index(string clientName, string serviceType, string workerName)
        {
            ViewBag.clientName = clientName;
            ViewBag.serviceType = serviceType;
            ViewBag.workerName = workerName;
            return View();
        }
        public ActionResult SearchResult(string clientName, string serviceType, string workerName)
        {
            var orders = db.Orders.Include(o => o.client).Include(o => o.service).Include(o => o.worker);
            if (clientName == null && serviceType == null && workerName == null)
                return View("GetOrders", orders.ToList());
            if (!clientName.Equals(""))
            {
                return View("GetOrders", orders.ToList().Where(x => x.client.ClientName.Contains(clientName)));
            }
            else if (!serviceType.Equals(""))
            {
                return View("GetOrders", orders.ToList().Where(x => x.service.ServiceType.Contains(serviceType)));
            }
            else if (!workerName.Equals(""))
            {
                return View("GetOrders", orders.ToList().Where(x => x.worker.WorkerName.Contains(workerName)));
            }
            else
            {
                return View("GetOrders", orders.ToList());
            }
        }
    }
}
