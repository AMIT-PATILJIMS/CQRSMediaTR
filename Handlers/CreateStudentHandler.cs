using CQRSMediaTR.Commands;
using CQRSMediaTR.Models;
using CQRSMediaTR.Repositories;
using MediatR;

namespace CQRSMediaTR.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetails = new StudentDetails()
            {
                StudentName = request.StudentName,
                StudentAddress = request.StudentAddress,
                StudentAge = request.StudentAge,
                StudentEmail = request.StudentEmail
            };

            return await _studentRepository.AddStudentAsync(studentDetails);
        }
    }
}
