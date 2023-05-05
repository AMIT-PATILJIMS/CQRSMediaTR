using MediatR;
using CQRSMediaTR.Models;
using CQRSMediaTR.Commands;
using CQRSMediaTR.Repositories;
using CQRSAndMediatRDemo.Commands;

namespace CQRSMediaTR.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository;
        }
        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(request.Id);

            if (studentDetails == null)
            {
                return default;
            }

            else
            {
                studentDetails.StudentName = request.StudentName;
                studentDetails.StudentEmail = request.StudentEmail;
                studentDetails.StudentAge = request.StudentAge;
                studentDetails.StudentAddress = request.StudentAddress;

                return await _studentRepository.UpdateStudentAsync(studentDetails);
            }
        }
    }
}
