
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Riven.Authorization;
using Riven.Extensions;
using Riven.ListViewInfos.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Riven.ListViewInfos
{
    [PermissionAuthorize]
    public class ListViewInfoAppService : ApplicationServiceBase, IListViewInfoAppService
    {
        protected readonly IListViewInfoManager _listViewInfoManager;
        public ListViewInfoAppService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            this._listViewInfoManager = this.GetService<IListViewInfoManager>();
        }

        [HttpGet]
        public async Task<ListViewInfoDto> GetListViewInfo(string name)
        {
            return new ListViewInfoDto()
            {
                Filters = await this.GetFilters(name),
                Columns = await this.GetColumns(name)
            };
        }

        [HttpGet]
        public async Task<IList<PageFilterItemDto>> GetFilters(string name)
        {
            var entitys = await this._listViewInfoManager.PageFilterItemManager
                .FindAll(name, AppSession.UserId, AppSession.TenantName);

            return entitys.MapTo<IList<PageFilterItemDto>>();
        }

        [HttpGet]
        public async Task<IList<PageColumnItemDto>> GetColumns(string name)
        {
            var entitys = await this._listViewInfoManager.PageColumnItemManager
                .FindAll(name, AppSession.UserId, AppSession.TenantName);

            return entitys.MapTo<IList<PageColumnItemDto>>();

        }

        [HttpPost]
        public async Task UpdateFilter(UpdatePageFiltersInput input)
        {
            await this._listViewInfoManager.PageFilterItemManager
                .Delete(input.Name, AppSession.UserId, AppSession.TenantName);

            var entitys = input.Filters.MapTo<List<PageFilterItem>>();
            foreach (var item in entitys)
            {
                item.Name = input.Name;
            }

            await this._listViewInfoManager.PageFilterItemManager
                .Create(entitys);
        }

        [HttpPost]
        public async Task UpdateColumns(UpdatePageColumnsInput input)
        {
            await this._listViewInfoManager.PageColumnItemManager
                .Delete(input.Name, AppSession.UserId, AppSession.TenantName);

            var entitys = input.Columns.MapTo<List<PageColumnItem>>();
            foreach (var item in entitys)
            {
                item.Name = input.Name;
            }

            await this._listViewInfoManager.PageColumnItemManager
                .Create(entitys);
        }
    }
}
