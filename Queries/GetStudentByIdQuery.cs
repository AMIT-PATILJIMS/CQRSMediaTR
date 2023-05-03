using CQRSMediaTR.Models;
using MediatR;

namespace CQRSMediaTR.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDetails>
    {
        public int Id { get; set; }
    }
}
