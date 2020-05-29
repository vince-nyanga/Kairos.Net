using Kairos.Net.Models;
using System;
using System.Threading.Tasks;

namespace Kairos.Net.Interfaces
{
    public interface IKairosClient
    {
        /// <summary>
        /// Takes a photo and returns the facial features it finds
        /// </summary>
        /// <param name="base64Image">Base64 encoded image</param>
        /// <param name="selector">Used to adjust the face detector. If not specified 'ROLL' is used</param>
        /// <returns><see cref="DetectFacesResponse"/></returns>
        Task<DetectFacesResponse> DetectFacesAsync(Base64Image base64Image, string selector = "ROLL");

        /// <summary>
        /// Takes a photo and returns the facial features it finds
        /// </summary>
        /// <param name="imageUri">Publicly accessible URL</param>
        /// <param name="selector">Used to adjust the face detector. If not specified 'ROLL' is used</param>
        /// <returns><see cref="DetectFacesResponse"/></returns>
        Task<DetectFacesResponse> DetectFacesAsync(Uri imageUri, string selector = "ROLL");

        /// <summary>
        /// Takes a photo, finds the faces within it, and stores them into a gallery
        /// </summary>
        /// <param name="base64Image">Base64 encoded image</param>
        /// <param name="subjectId">Identifier for the person being enrolled</param>
        /// <param name="galleryName">Name of gallery to which the face will be stored</param>
        /// <returns><see cref="EnrollFaceResponse"/></returns>
        Task<EnrollFaceResponse> EnrollFaceAsync(Base64Image base64Image, string subjectId, string galleryName);

        /// <summary>
        /// Takes a photo, finds the faces within it, and stores them into a gallery
        /// </summary>
        /// <param name="imageUri">Publicly accessible URL</param>
        /// <param name="subjectId">Identifier for the person being enrolled</param>
        /// <param name="galleryName">Name of gallery to which the face will be stored</param>
        /// <returns><see cref="EnrollFaceResponse"/></returns>
        Task<EnrollFaceResponse> EnrollFaceAsync(Uri imageUri, string subjectId, string galleryName);

        /// <summary>
        /// Lists all faces enrolled in a gallery
        /// </summary>
        /// <param name="galleryName">Gallery name</param>
        /// <returns><see cref="ListFacesResponse"/></returns>
        Task<ListFacesResponse> ListFacesAsync(string galleryName);

        /// <summary>
        /// Lists all galleries created
        /// </summary>
        /// <returns><see cref="GalleryListResponse"/></returns>
        Task<GalleryListResponse> ListGalleriesAsync();

        /// <summary>
        /// Takes a photo, finds the faces within it, and tries to match them against faces enrolled in the gallery
        /// </summary>
        /// <param name="base64Image">Base64 encoded image</param>
        /// <param name="galleryName">Gallery name</param>
        /// <returns><see cref="RecognizeFaceResponse"/></returns>
        Task<RecognizeFaceResponse> RecognizeFaceAsync(Base64Image base64Image, string galleryName);

        /// <summary>
        /// Takes a photo, finds the faces within it, and tries to match them against faces enrolled in the gallery
        /// </summary>
        /// <param name="imageUri">Publicly accessible URL</param>
        /// <param name="galleryName">Gallery name</param>
        /// <returns><see cref="RecognizeFaceResponse"/></returns>
        Task<RecognizeFaceResponse> RecognizeFaceAsync(Uri imageUri, string galleryName);

        /// <summary>
        /// Deletes a gallery and all faces enrolled therein
        /// </summary>
        /// <param name="galleryName">Gallery name</param>
        /// <returns><see cref="RemoveGalleryResponse"/></returns>
        Task<RemoveGalleryResponse> RemoveGalleryAsync(string galleryName);

        /// <summary>
        /// Takes a photo, finds the face within it, and tries to compare it against a face already enrolled into a gallery
        /// </summary>
        /// <param name="base64Image">Base64 encoded image</param>
        /// <param name="subjectId">Identifier for the person being verified</param>
        /// <param name="galleryName">Gallery name</param>
        /// <returns><see cref="VerifyFaceResponse"/></returns>
        Task<VerifyFaceResponse> VerifyFaceAsync(Base64Image base64Image, string subjectId, string galleryName);

        /// <summary>
        /// Takes a photo, finds the face within it, and tries to compare it against a face already enrolled into a gallery
        /// </summary>
        /// <param name="imageUri">Publicly accessible URL</param>
        /// <param name="subjectId">Identifier for the person being verified</param>
        /// <param name="galleryName">Gallery name</param>
        /// <returns><see cref="VerifyFaceResponse"/></returns>
        Task<VerifyFaceResponse> VerifyFaceAsync(Uri imageUri, string subjectId, string galleryName);
    }
}