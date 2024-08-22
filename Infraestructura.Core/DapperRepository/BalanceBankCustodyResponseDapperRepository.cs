using Infraestructura.Core.DapperRepository.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Infraestructura.Core.DapperRepository
{
    [ExcludeFromCodeCoverage]
    public class BalanceBankCustodyResponseDapperRepository : IBalanceBankCustodyResponseDapperRepository
    {
        /// <summary>
        /// The dapper repository
        /// </summary>
        /*
        private readonly IDapperRepository<BalanceBankCustodyResponseDapperDto> _dapperRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="dapperRepository"></param>
        public BalanceBankCustodyResponseDapperRepository(IDapperRepository<BalanceBankCustodyResponseDapperDto> dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<IEnumerable<BalanceBankCustodyResponseDapperDto>> GetBalanceBankCustody(List<int> accountIds)
        {
            string query = Resources.QuerysResources.GetBalanceBankCustody;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@accountIds", string.Join(",", accountIds));
            IEnumerable<BalanceBankCustodyResponseDapperDto> resultDapper = await _dapperRepository.ExecuteStoreProcedureAsync(query, parameters);
            return resultDapper;
        }
        */
    }
}
