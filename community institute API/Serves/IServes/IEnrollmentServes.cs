﻿using community_institute_API.Data.Domin;

namespace community_institute_API.Serves.IServes
{
    public interface IEnrollmentServes
    {


        Task<bool> AddEnrollmentAsync(int studentId, int classId);
        Task<bool> ApproveEnrollmentAsync(int enrollmentId);
        Task<bool> DenyEnrollmentAsync(int enrollmentId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsAsync();
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentAsync(int studentId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByClassAsync(int classId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByClassAndProfessorAsync(int classId, int professorId);
    }
}
