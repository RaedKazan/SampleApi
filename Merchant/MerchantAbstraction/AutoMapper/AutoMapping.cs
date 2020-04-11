﻿using AutoMapper;
using MerchantAbstraction.ViewModels.Images;
using MerchantAbstraction.ViewModels.Locations;
using MerchantAbstraction.ViewModels.Merchants;
using MerchantData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantAbstraction.AutoMapper
{
    class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region Image
            CreateMap<CreateImageDTO, Image>()
                .ForMember(dest => dest.ImageData, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.ImageBase64Data)))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ImageTitle, opt => opt.MapFrom(src => src.ImageTitle));

            CreateMap<UpdateImageDTO, Image>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ImageData, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.ImageBase64Data)))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ImageTitle, opt => opt.MapFrom(src => src.ImageTitle));

            CreateMap<Image, ImageDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ImageBase64Data, opt => opt.MapFrom(src => Convert.ToBase64String(src.ImageData)))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ImageTitle, opt => opt.MapFrom(src => src.ImageTitle));
            #endregion

            #region Location

            CreateMap<CreateLocationDTO, Location>()
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber))
                .ForMember(dest => dest.FloorNumber, opt => opt.MapFrom(src => src.FloorNumber));

            CreateMap<UpdateLocationDTO, Location>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber))
                .ForMember(dest => dest.FloorNumber, opt => opt.MapFrom(src => src.FloorNumber));

            CreateMap<Location, CreateLocationDTO>();

            #endregion

            #region Merchant

            CreateMap<CreateMerchantDTO, MerchantInfo>()
              .ForMember(dest => dest.ShopName, opt => opt.MapFrom(src => src.ShopName))
              .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
              .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
              .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.ServiceType))
              .ForMember(dest => dest.FreeDeliveryActive, opt => opt.MapFrom(src => src.FreeDeliveryActive))
              .ForMember(dest => dest.StartWorkingHour, opt => opt.MapFrom(src => src.StartWorkingHour))
              .ForMember(dest => dest.StopWorkingHour, opt => opt.MapFrom(src => src.StopWorkingHour))
              .ForMember(dest => dest.AcceptedTypeOfPayment, opt => opt.MapFrom(src => src.AcceptedTypeOfPayment))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
              .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
              .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => false));


            CreateMap<UpdateMerchantDTO, MerchantInfo>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.ShopName, opt => opt.MapFrom(src => src.ShopName))
              .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
              .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
              .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.ServiceType))
              .ForMember(dest => dest.FreeDeliveryActive, opt => opt.MapFrom(src => src.FreeDeliveryActive))
              .ForMember(dest => dest.StartWorkingHour, opt => opt.MapFrom(src => src.StartWorkingHour))
              .ForMember(dest => dest.StopWorkingHour, opt => opt.MapFrom(src => src.StopWorkingHour))
              .ForMember(dest => dest.AcceptedTypeOfPayment, opt => opt.MapFrom(src => src.AcceptedTypeOfPayment))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
              .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
              .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
              .ForMember(dest => dest.HasPromoCode, opt => opt.MapFrom(src => src.HasPromoCode))
              .ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy));

            CreateMap<MerchantInfo, MerchantDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.ShopName, opt => opt.MapFrom(src => src.ShopName))
              .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
              .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId))
              .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
              .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.ServiceType))
              .ForMember(dest => dest.FreeDeliveryActive, opt => opt.MapFrom(src => src.FreeDeliveryActive))
              .ForMember(dest => dest.StartWorkingHour, opt => opt.MapFrom(src => src.StartWorkingHour))
              .ForMember(dest => dest.StopWorkingHour, opt => opt.MapFrom(src => src.StopWorkingHour))
              .ForMember(dest => dest.AcceptedTypeOfPayment, opt => opt.MapFrom(src => src.AcceptedTypeOfPayment))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
              .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
              .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
              .ForMember(dest => dest.HasPromoCode, opt => opt.MapFrom(src => src.HasPromoCode))
              .ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy));
            #endregion
        }
    }
}