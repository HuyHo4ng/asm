﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asm.Data;
using asm.Models;

namespace asm.Controllers
{
    public class EnrolmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrolmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enrolments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enrolment.Include(e => e.Course).Include(e => e.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enrolments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrolmentID == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        // GET: Enrolments/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Course, "courseID", "courseID");
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "StudentID", "StudentID");
            return View();
        }

        // POST: Enrolments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrolmentID,StudentID,CourseID,Grade")] Enrolment enrolment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrolment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Course, "courseID", "courseID", enrolment.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "StudentID", "StudentID", enrolment.StudentID);
            return View(enrolment);
        }

        // GET: Enrolments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment.FindAsync(id);
            if (enrolment == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Course, "courseID", "courseID", enrolment.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "StudentID", "StudentID", enrolment.StudentID);
            return View(enrolment);
        }

        // POST: Enrolments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrolmentID,StudentID,CourseID,Grade")] Enrolment enrolment)
        {
            if (id != enrolment.EnrolmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrolment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrolmentExists(enrolment.EnrolmentID))
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
            ViewData["CourseID"] = new SelectList(_context.Course, "courseID", "courseID", enrolment.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Set<Student>(), "StudentID", "StudentID", enrolment.StudentID);
            return View(enrolment);
        }

        // GET: Enrolments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrolmentID == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        // POST: Enrolments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrolment = await _context.Enrolment.FindAsync(id);
            _context.Enrolment.Remove(enrolment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrolmentExists(int id)
        {
            return _context.Enrolment.Any(e => e.EnrolmentID == id);
        }
    }
}
