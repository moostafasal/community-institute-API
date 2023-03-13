using community_institute_API.Data;
using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace community_institute_API.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly ComContext _dbContext;

        public EnrollmentService(ComContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ApproveEnrollment(int enrollmentId)
        {
            var enrollment = await _dbContext.Enrollments.FindAsync(enrollmentId);
            if (enrollment == null)
            {
                return false;
            }

            enrollment.states = true;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RejectEnrollment(int enrollmentId)
        {
            var enrollment = await _dbContext.Enrollments.FindAsync(enrollmentId);
            if (enrollment == null)
            {
                return false;
            }

            _dbContext.Enrollments.Remove(enrollment);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsForClass(int classId)
        {
            return await _dbContext.Enrollments
                .Include(e => e.Student)
                .Where(e => e.classid == classId && !e.states)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsForStudent(int studentId)
        {
            return await _dbContext.Enrollments
                .Include(e => e.clases)
                .Where(e => e.StudentId == studentId && e.states)
                .ToListAsync();
        }

        public async Task<Enrollment> CreateEnrollment(Enrollment enrollment)
        {
            var existingEnrollment = await _dbContext.Enrollments
                .Where(e => e.StudentId == enrollment.StudentId && e.classid == enrollment.classid)
                .FirstOrDefaultAsync();

            if (existingEnrollment != null)
            {
                return null;
            }

            _dbContext.Enrollments.Add(enrollment);
            await _dbContext.SaveChangesAsync();

            return enrollment;
        }
    }

    public interface IEnrollmentService
    {
        Task<bool> ApproveEnrollment(int enrollmentId);
        Task<bool> RejectEnrollment(int enrollmentId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsForClass(int classId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsForStudent(int studentId);
        Task<Enrollment> CreateEnrollment(Enrollment enrollment);
    }
}
