using CQRSMediaTR.Models;
using MediatR;

namespace CQRSMediaTR.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentDetails>>
    {
    }
}
