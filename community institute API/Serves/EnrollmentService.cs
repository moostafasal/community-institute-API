using community_institute_API.Data;
using community_institute_API.Data.Domin;
using community_institute_API.Serves.IServes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace community_institute_API.Services
{
    public class EnrollmentService : IEnrollmentServes
    {
        private readonly ComContext _context;

        public EnrollmentService(ComContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEnrollmentAsync(int studentId, int classId)
        {
            var student = await _context.Students.FindAsync(studentId);
            var @class = await _context.clases.FindAsync(classId);

            if (student == null || @class == null)
            {
                return false;
            }
            var existingEnrollment = await _context.Enrollments
    .FirstOrDefaultAsync(e => e.StudentId == studentId && e.classid == classId);

            if (existingEnrollment != null)
            {
                return false; // Return false to indicate that the enrollment already exists
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                classid = classId,
                states = false
            };
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ApproveEnrollmentAsync(int enrollmentId)
        {
            var enrollment = await _context.Enrollments.FindAsync(enrollmentId);
            if (enrollment == null)
            {
                return false;
            }
            enrollment.states = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DenyEnrollmentAsync(int enrollmentId)
        {
            var enrollment = await _context.Enrollments.FindAsync(enrollmentId);
            if (enrollment == null)
            {
                return false;
            }
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsAsync()
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.clases).ThenInclude(e=>e.ProfessorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentAsync(int studentId)
        {
            return await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Student)
                .Include(e => e.clases)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByClassAsync(int classId)
        {
            return await _context.Enrollments
                .Where(e => e.classid == classId)
                .Include(e => e.Student)
                .Include(e => e.clases)
                .ToListAsync();
        }
        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByClassAndProfessorAsync(int classId, int professorId)
        {
            return await _context.Enrollments
                .Where(e => e.classid == classId && e.clases.ProfessorId == professorId)
                .Include(e => e.Student)
                .Include(e => e.clases)
                .ToListAsync();
        }

    }


}
