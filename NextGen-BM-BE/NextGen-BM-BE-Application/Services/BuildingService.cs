using AutoMapper;
using NextGen_BM_BE_Application.UseCases.Buildings.Create;
using NextGen_BM_BE_Application.UseCases.Buildings.Delete;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using NextGen_BM_BE_Application.UseCases.Buildings.Update;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly GetBuildingByIdUseCase _getBuildingByIdUseCase;
        private readonly GetAllBuildingsUseCase _getAllBuildingsUseCase;
        private readonly CreateBuildingUseCase _createBuildingUseCase;
        private readonly UpdateBuildingUseCase _updateBuildingUseCase;
        private readonly DeleteBuildingUseCase _deleteBuildingUseCase;
        private readonly DeleteUserBuildingLinkUseCase _deleteUserBuildingLinkUseCase;
        private readonly GetBuildingsByUserIdUseCase _getBuildingsByUserIdUseCase;
        private readonly IMapper _mapper;

        public BuildingService(
            GetBuildingsByUserIdUseCase getBuildingsByUserIdUseCase,
            GetBuildingByIdUseCase getBuildingByIdUseCase,
            GetAllBuildingsUseCase getAllBuildingsUseCase,
            CreateBuildingUseCase createBuildingUseCase,
            UpdateBuildingUseCase updateBuildingUseCase,
            DeleteBuildingUseCase deleteBuildingUseCase,
            DeleteUserBuildingLinkUseCase deleteUserBuildingLinkUseCase,
            IMapper mapper
        )
        {
            _getBuildingsByUserIdUseCase = getBuildingsByUserIdUseCase;
            _getBuildingByIdUseCase = getBuildingByIdUseCase;
            _getAllBuildingsUseCase = getAllBuildingsUseCase;
            _createBuildingUseCase = createBuildingUseCase;
            _updateBuildingUseCase = updateBuildingUseCase;
            _deleteBuildingUseCase = deleteBuildingUseCase;
            _deleteUserBuildingLinkUseCase = deleteUserBuildingLinkUseCase;
            _mapper = mapper;
        }

        public async Task<BuildingViewModel> GetBuildingByIdAsync(int buildingId)
        {
            var building =  await _getBuildingByIdUseCase.Execute(buildingId);
            return _mapper.Map<BuildingViewModel>(building);
        }

        public async Task<IList<BuildingViewModel>> GetAllBuildingsAsync()
        {
            var buildings = await _getAllBuildingsUseCase.Execute();
            List<BuildingViewModel> buildingsList = new();
            foreach(var building in buildings){
                buildingsList.Add(_mapper.Map<BuildingViewModel>(building));
            }
            return buildingsList;
        }

        public async Task<IList<BuildingViewModel>> GetBuildingsByUserIdAsync(int userId)
        {
            var buildings = await _getBuildingsByUserIdUseCase.Execute(userId);
            List<BuildingViewModel> buildingsList = new();
            foreach (var building in buildings)
            {
                buildingsList.Add(_mapper.Map<BuildingViewModel>(building));
            }
            return buildingsList;
        }

        public async Task CreateBuildingAsync(BuildingViewModel buildingDto)
        {
            var building = _mapper.Map<Building>(buildingDto);
            await _createBuildingUseCase.Execute(building);
        }

        public async Task UpdateBuildingAsync(BuildingViewModel buildingDto)
        {
            var building = _mapper.Map<Building>(buildingDto);
            await _updateBuildingUseCase.Execute(building);
        }

        public async Task DeleteBuildingAsync(int buildingId)
        {
            await _deleteBuildingUseCase.Execute(buildingId);
        }

        public async Task DeleteUserBuildingLinkAsync(int userId, int buildingId)
        {
            await _deleteUserBuildingLinkUseCase.Execute(userId, buildingId);
        }
    }
}
