using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace LoanManagementSystem.Service
{
    public class CollateralDocumentService : ICollateralDocumentService
    {
        private  readonly ICollateralDocumentRepository _collateralDocumentRepository;

        public CollateralDocumentService(ICollateralDocumentRepository collateralDocumentRepository)
        {
            _collateralDocumentRepository = collateralDocumentRepository;
        }



        //public async Task UploadFile(CollateralDocumentDTO collateralDocumentDTO)
        //{
        //    await _collateralDocumentRepository.SaveCollateralDocument(collateralDocumentDTO);
        //}

        //public async Task<IActionResult> DownloadFile(string filename)
        //{
        //    return await _collateralDocumentRepository.GetCollateralDocumentByFileName(filename);
        //}



        //private ICollateralDocumentRepository _collateralDocumentRepository;

        //public CollateralDocumentService(ICollateralDocumentRepository collateralDocumentRepository)
        //{
        //    _collateralDocumentRepository = collateralDocumentRepository;
        //}
        //public void AddCollateralDocument(CollateralDocument collateralDocument)
        //{
        //    _collateralDocumentRepository.Add(collateralDocument);
        //}
        //public List<CollateralDocument> DisplayCollateralDocument()
        //{
        //    return _collateralDocumentRepository.Display();
        //}
        //public CollateralDocument FindCollateralDocument(int id)
        //{
        //    return _collateralDocumentRepository.Find(id);
        //}
        //public void UpdateCollateralDocument(CollateralDocument collateralDocument)
        //{
        //    _collateralDocumentRepository.Update(collateralDocument);
        //}
        //public void DeleteCollateralDocument(int id)
        //{
        //    _collateralDocumentRepository.Delete(id);
        //}
    }
}
