using AutoMapper;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;


namespace NextGen_BM_BE_Application.Services;

public class BuildingService: IBuildingService
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IMapper _mapper;
    public BuildingService(IBuildingRepository buildingRepository, IMapper mapper)
    {
        _mapper = mapper;
        _buildingRepository = buildingRepository;
    }

    public async Task CreateBuildingAsync(BuildingViewModel buildingDto){
        var building = _mapper.Map<Building>(buildingDto);
        await _buildingRepository.CreateBuildingAsync(building);
    }

    public async Task DeleteBuildingAsync(int buildingId)
    {
        await _buildingRepository.DeleteBuildingAsync(buildingId);
    }

    public async Task<List<Building>> GetAllBuildingsAsync(){
        return await _buildingRepository.GetAllBuildingsAsync();
    }

    public async Task<Building> GetBuildingByIdAsync(int buildingId)
    {
        return await _buildingRepository.GetBuildingByIdAsync(buildingId);
    }

    public async Task UpdateBuildingAsync(BuildingViewModel buildingDto)
    {
        var building = _mapper.Map<Building>(buildingDto);
        await _buildingRepository.UpdateBuildingAsync(building);
    }
}