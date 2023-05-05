using CQRSAndMediatRDemo.Commands;
using CQRSMediaTR.Repositories;
using MediatR;

namespace CQRSMediaTR.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentHandler(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetail = await _studentRepository.GetStudentByIdAsync(request.Id);

            if (studentDetail == null)
            {
                return default;
            }

            else 
            {
                return await _studentRepository.DeleteStudentAsync(studentDetail.Id);
            }
        }
    }
}
