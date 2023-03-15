using community_institute_API.Data.Domin;

namespace community_institute_API.Serves.IServes
{
    public interface IEnrollmentServes
    {
        //Task<Enrollment> GetEnrollmentByIdAsync(int id);
        //Task<List<Enrollment>> GetAllEnrollmentsAsync();
        //Task<List<Enrollment>> GetAllEnrollmentsByClassIdAsync(int classId);
        //Task<List<Enrollment>> GetAllEnrollmentsByStudentIdAsync(int studentId);
        //Task<List<Enrollment>> GetPendingEnrollmentsByClassIdAsync(int classId);
        //Task<Enrollment> EnrollStudentInClassAsync(int studentId, int classId);
        //Task<Enrollment> ApproveEnrollmentAsync(int enrollmentId);
        //Task DeleteEnrollmentAsync(int enrollmentId);

        Task<bool> AddEnrollmentAsync(int studentId, int classId);
        Task<bool> ApproveEnrollmentAsync(int enrollmentId);
        Task<bool> DenyEnrollmentAsync(int enrollmentId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsAsync();
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentAsync(int studentId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByClassAsync(int classId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByClassAndProfessorAsync(int classId, int professorId);



    }
}
