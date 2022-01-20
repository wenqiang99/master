using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MyPractice.Authorization
{
    /// <summary>
    /// 权限
    /// </summary>
    public class MyPracticeAuthorizationProvider : AuthorizationProvider
    {
        /// <summary>
        /// 配置权限
        /// </summary>
        /// <param name="context"></param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            this.SysPerms(context);
        }
        /// <summary>
        /// 配置权限
        /// </summary>
        /// <param name="context"></param>
        private void SysPerms(IPermissionDefinitionContext context)
        {
            #region 初始
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            #endregion
            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages")); //首页
            var order = pages.CreateChildPermission(PermissionNames.Pages_Orders, L("Order")); //订单
            var orderadmin = order.CreateChildPermission(PermissionNames.Pages_Orders_Administration, L("Administration")); //管理
            var orderadminbasicdata = orderadmin.CreateChildPermission(PermissionNames.Pages_Orders_Administration_BasicData, L("BasicData")); // 基础数据
            #region
            //#region 工作单导入
            ////工作单导入
            //var WorkOrderImportMpc = pages.CreateChildPermission(PermissionNames.Pages_WorkOrderImportMpc, L("WorkOrderImportMpc"));
            ////工作单导入
            //var WorkOrderImportToMpc = WorkOrderImportMpc.CreateChildPermission(PermissionNames.Pages_WorkOrderImportMpc_WorkOrderImportToMpc, L("WorkOrderImportMpc"));
            //#endregion

            //#region 基础数据
            ////基础数据
            //var basicdatampc = pages.CreateChildPermission(PermissionNames.Pages_BasicData, L("BasicData"));
            ////设备
            //var mechlandmpc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_MechLandMpc, L("BasicData_MechLandMpc"));
            ////区域
            //var mechlandtypempc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_MechLandTypeMpc, L("BasicData_MechLandTypeMpc"));
            ////工序
            //var mechlandstepmpc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_MechLandStepMpc, L("BasicData_MechLandStepMpc"));
            ////工厂
            //var factorympc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_FactoryMpc, L("BasicData_FactoryMpc"));
            ////原材料
            //var mernompc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_MerNOMpc, L("BasicData_MerNOMpc"));
            ////铣削原料
            //var millingmaterialmpc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_MillingMaterialMpc, L("BasicData_MillingMaterialMpc"));
            ////停机原因
            //var stopreasonmpc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_StopReasonMpc, L("BasicData_StopReasonMpc"));
            ////停机原因描述
            //var reasondescribempc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_ReasonDescribeMpc, L("BasicData_ReasonDescribeMpc"));
            ////检查项目数据管理
            //var checkdataforprojectmpc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_CheckDataforProjectMpc, L("BasicData_CheckDataforProjectMpc"));
            ////不铣削零件库
            //var notmateriaxxmpc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_NotMateriaXXMpc, L("BasicData_NotMateriaXXMpc"));
            ////不毛刺零件库
            //var notmateriamcmpc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_NotMateriaMCMpc, L("BasicData_NotMateriaMCMpc"));
            ////显示屏计划数量
            //var dataplandisplaympc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_DataPlanDisplayMpc, L("BasicData_DataPlanDisplayMpc"));
            ////班次时间维护
            //var weektimespotcheckmpc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_WeekTimeSpotCheckMpc, L("BasicData_WeekTimeSpotCheckMpc"));
            ////点检项目维护
            //var spotchecktermsmpc = basicdatampc.CreateChildPermission(PermissionNames.Pages_BasicData_SpotCheckTermsMpc, L("BasicData_SpotCheckTermsMpc"));
            //#endregion

            //#region 消息留言
            ////消息留言
            //var noticempc = pages.CreateChildPermission(PermissionNames.Pages_Notice, L("Notice"));
            ////我要留言
            //var addnoticemc = noticempc.CreateChildPermission(PermissionNames.Pages_Notice_AddNoticeMpc, L("AddNoticeMpc"));
            ////我的留言
            //var mynoticempc = noticempc.CreateChildPermission(PermissionNames.Pages_Notice_MyNoticeMpc, L("MyNoticeMpc"));
            //#endregion

            //#region 技术资料
            ////技术资料
            //var technicaldocumentmpc = pages.CreateChildPermission(PermissionNames.Pages_TechnicalDocument, L("TechnicalDocument"));
            ////技术资料上传
            //var documentuploadmpc = technicaldocumentmpc.CreateChildPermission(PermissionNames.Pages_TechnicalDocument_DocumentUploadMpc, L("DocumentUploadMpc"));
            ////技术资料管理
            //var documentmanagempc = technicaldocumentmpc.CreateChildPermission(PermissionNames.Pages_TechnicalDocument_DocumentManageMpc, L("DocumentManageMpc"));
            ////技术资料管理
            //var documentsearchmpc = technicaldocumentmpc.CreateChildPermission(PermissionNames.Pages_TechnicalDocument_DocumentSearchMpc, L("DocumentSearchMpc"));
            //#endregion

            //#region 权限管理
            ////权限管理
            //var permissionmanagempc = pages.CreateChildPermission(PermissionNames.Pages_PermissionManage, L("PermissionManage"));
            ////角色管理
            //permissionmanagempc.CreateChildPermission(PermissionNames.Pages_PermissionManage_DepartmentManageMpc, L("DepartmentManageMpc"));
            ////用户管理
            //permissionmanagempc.CreateChildPermission(PermissionNames.Pages_PermissionManage_GroupManageMpc, L("GroupManageMpc"));
            ////加工用户组设置
            //permissionmanagempc.CreateChildPermission(PermissionNames.Pages_PermissionManage_UserFlowGroupMpc, L("UserFlowGroupMpc"));
            //#endregion

            //#region 停机记录

            ////停机记录
            //var devicemistakempc = pages.CreateChildPermission(PermissionNames.Pages_DeviceMistake, L("DeviceMistake"));
            ////停机记录录入
            //var deviceaddmpc = devicemistakempc.CreateChildPermission(PermissionNames.Pages_DeviceMistake_DeviceAddMpc, L("DeviceAddMpc"));
            ////停机记录查询
            //var devicesearchmpc = devicemistakempc.CreateChildPermission(PermissionNames.Pages_DeviceMistake_DeviceSearchMpc, L("DeviceSearchMpc"));
            ////停机记录管理
            //var devicemanagempc = devicemistakempc.CreateChildPermission(PermissionNames.Pages_DeviceMistake_DeviceManageMpc, L("DeviceManageMpc"));
            //#endregion

            //#region 库存记录
            ////库存记录
            //var stockmpc = pages.CreateChildPermission(PermissionNames.Pages_StockMpc, L("StockMpc"));
            ////库存记录录入
            //var stockaddmpc = stockmpc.CreateChildPermission(PermissionNames.Pages_StockMpc_StockAddMpc, L("StockAddMpc"));
            ////库存记录查询
            //var stocksearchmpc = stockmpc.CreateChildPermission(PermissionNames.Pages_StockMpc_StockSearchMpc, L("StockSearchMpc"));
            ////库存记录管理
            //var stockmanagempc = stockmpc.CreateChildPermission(PermissionNames.Pages_StockMpc_StockManageMpc, L("StockManageMpc"));
            //#endregion

            //#region 综合查询
            ////综合查询
            //var SearchTotalMpc = pages.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc, L("SearchTotalMpc"));

            ////详细综合查询
            //var SearchRecordMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_SearchRecordMpc, L("SearchRecordMpc"));
            ////综合查询
            //var SearchTotalToMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_SearchTotalToMpc, L("SearchTotalToMpc"));

            ////综合查询 打印
            //var stmPrinting = SearchTotalToMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_SearchTotalToMpc_Printing, L("STM_Printing"));
            ////综合查询 删除
            //var stmDelete = SearchTotalToMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_SearchTotalToMpc_Delete, L("STM_Delete"));
            ////综合查询 工程库存收回
            //var stmProjectInventoryRecovery = SearchTotalToMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_SearchTotalToMpc_ProjectInventoryRecovery, L("STM_ProjectInventoryRecovery"));
            ////综合查询 备份勾选
            //var stmBackupCheck = SearchTotalToMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_SearchTotalToMpc_BackupCheck, L("STM_BackupCheck"));
            ////综合查询 备份所有
            //var stmBackUpAll = SearchTotalToMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_SearchTotalToMpc_BackUpAll, L("STM_BackUpAll"));
            ////综合查询 库存打印
            //var stmInventoryPrinting = SearchTotalToMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_SearchTotalToMpc_InventoryPrinting, L("STM_InventoryPrinting"));

            ////周计划表
            //var WeekPlanMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_WeekPlanMpc, L("WeekPlanMpc"));
            ////进度表
            //var WorkProcessMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_WorkProcessMpc, L("WorkProcessMpc"));
            ////计划表
            //var WorkPlanProcessMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_WorkPlanProcessMpc, L("WorkPlanProcessMpc"));
            ////钣金统计报表
            //var ReportBJMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_ReportBJMpc, L("ReportBJMpc"));
            ////铜排统计报表
            //var ReportTPMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_ReportTPMpc, L("ReportTPMpc"));
            ////检验项统计报表
            //var ReportCheckMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_ReportCheckMpc, L("ReportCheckMpc"));
            ////综合查询管理
            //var SearchTotalManageMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_SearchTotalManageMpc, L("SearchTotalManageMpc"));
            ////NC程序查询
            //var NCProgramMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_NCProgramMpc, L("NCProgramMpc"));
            ////图纸查询
            //var DrawingSearchMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_DrawingSearchMpc, L("DrawingSearchMpc"));
            ////点检数据查询
            //var SearchCheckSpotDataMpc = SearchTotalMpc.CreateChildPermission(PermissionNames.Pages_SearchTotalMpc_SearchCheckSpotDataMpc, L("SearchCheckSpotDataMpc"));
            //#endregion

            //#region 工时基础数据
            ////工时基础数据
            //var WorkHoursDataMpc = pages.CreateChildPermission(PermissionNames.Pages_WorkHoursDataMpc, L("WorkHoursDataMpc"));
            ////调整系数
            //var CoefficientsMpc = WorkHoursDataMpc.CreateChildPermission(PermissionNames.Pages_WorkHoursDataMpc_CoefficientsMpc, L("CoefficientsMpc"));
            ////工艺类型
            //var CraftTypeMpc = WorkHoursDataMpc.CreateChildPermission(PermissionNames.Pages_WorkHoursDataMpc_CraftTypeMpc, L("CraftTypeMpc"));
            ////工艺种类
            //var TreatmentMpc = WorkHoursDataMpc.CreateChildPermission(PermissionNames.Pages_WorkHoursDataMpc_TreatmentMpc, L("TreatmentMpc"));
            //#endregion

            //#region 日志查询
            ////日志查询
            //var OperateLogSearchMpc = pages.CreateChildPermission(PermissionNames.Pages_OperateLogSearchMpc, L("OperateLogSearchMpc"));
            ////日志查询
            //var OperateLogSearchChildMpc = OperateLogSearchMpc.CreateChildPermission(PermissionNames.Pages_OperateLogSearchMpc_OperateLogSearchChildMpc, L("OperateLogSearchMpc"));
            //#endregion


            #endregion
            #region 注释焊接
            ////系统管理
            //var administration = pages.CreateChildPermission(PermissionNamesTest.Pages_Administration, L("Administration"));
            ////系统管理--桌面
            //var desktop = administration.CreateChildPermission(PermissionNamesTest.Pages_Administration_DeskTop, L("DeskTop"));
            ////系统管理--角色管理
            //var roles = administration.CreateChildPermission(PermissionNamesTest.Pages_Administration_Roles, L("Roles"));
            ////系统管理--用户管理
            //var users = administration.CreateChildPermission(PermissionNamesTest.Pages_Administration_Users, L("Users"));

            ////基础数据维护
            //var basicdata = pages.CreateChildPermission(PermissionNamesTest.Pages_BasicData, L("BasicData"));
            ////基础数据维护--工序维护
            //var procedures = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_Procedures, L("Procedures"));
            ////基础数据维护--检验项维护
            //var InspectionItems = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_InspectionItems, L("InspectionItems"));
            ////基础数据维护--SO1维护
            //var SO1 = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_SO1, L("SO1"));
            ////基础数据维护--程序维护
            //var programs = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_Programs,L("Programs"));
            ////基础数据维护--外围模板维护
            //var remlowtempls = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_RemLowTempls, L("RemLowTempls"));
            ////基础数据维护--设备维护
            //var devices = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_Devices, L("Devices"));
            ////基础数据维护--区域维护
            //var areas = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_Areas, L("Areas"));
            ////基础数据维护--停机原因维护
            //var downreasons = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_DownReasons, L("DownReasons"));
            ////基础数据维护--邮件模板维护
            //var emailtemplate = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_EmailTemplate, L("EmailTemplate"));
            ////基础数据维护--邮件模板发送者维护
            //var emailto = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_EmailTo, L("EmailTo"));
            ////基础数据维护--气室结构维护
            //var gas = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_Gas, L("Gas"));
            ////基础数据维护--权重类型维护
            //var typeweight = basicdata.CreateChildPermission(PermissionNamesTest.Pages_BasicData_TypeWeight, L("TypeWeight"));

            ////停机记录
            //var downdata = pages.CreateChildPermission(PermissionNamesTest.Pages_DownData, L("DownData"));
            ////停机记录--停机记录录入
            //var downdatainput = downdata.CreateChildPermission(PermissionNamesTest.Pages_DownData_DownDataInput, L("DownDataInput"));
            ////停机记录--停机记录查询
            //var downdatasearch = downdata.CreateChildPermission(PermissionNamesTest.Pages_DownData_DownDataSearch, L("DownDataSearch"));
            ////停机记录--停机记录管理
            //var downdatamanage = downdata.CreateChildPermission(PermissionNamesTest.Pages_DownData_DownDataManage, L("DownDataManage"));

            ////工艺设定
            //var technology = pages.CreateChildPermission(PermissionNamesTest.Pages_Technology, L("Technology"));
            ////工艺设定--焊接生产工艺
            //var producttech = technology.CreateChildPermission(PermissionNamesTest.Pages_Technology_ProductTech, L("ProductTech"));
            ////工艺设定--焊接工艺设定
            //var techsetting = technology.CreateChildPermission(PermissionNamesTest.Pages_Technology_TechSetting, L("TechSetting"));

            ////工作单导入
            //var worksheetimport = pages.CreateChildPermission(PermissionNamesTest.Pages_WorkSheetImport, L("WorkSheetImport"));
            ////工作单导入--SAP开单数据导入
            //var saporderimport = worksheetimport.CreateChildPermission(PermissionNamesTest.Pages_WorkSheetImport_SAPOrderImport, L("SAPOrderImport"));

            ////生产单
            //var productionorder = pages.CreateChildPermission(PermissionNamesTest.Pages_ProductionOrder, L("ProductionOrder"));
            ////技术资料上传
            //var productionordertechnicaldata = productionorder.CreateChildPermission(PermissionNamesTest.Pages_ProductionOrder_TechnicalData, L("TechnicalData"));
            ////生产单主页面
            //var productionordermain = productionorder.CreateChildPermission(PermissionNamesTest.Pages_ProductionOrder_Main, L("ProductionOrderMain"));
            ////缺料信息表
            //var productionshortage = productionorder.CreateChildPermission(PermissionNamesTest.Pages_ProductionOrder_Shortage, L("ProductionShortage"));
            ////关单统计表
            //var productionorderclose = productionorder.CreateChildPermission(PermissionNamesTest.Pages_ProductionOrder_Close, L("ProductionOrderClose"));
            ////到料统计表
            //var productionarrivalstatistics = productionorder.CreateChildPermission(PermissionNamesTest.Pages_ProductionOrder_ArrivalStatistics, L("ProductionArrivalStatistics"));
            ////壳体统计表
            //var productionshellstatistics = productionorder.CreateChildPermission(PermissionNamesTest.Pages_ProductionOrder_Shellstatistics, L("ProductionShellStatistics"));

            ////留言管理
            //var messagemanagement = pages.CreateChildPermission(PermissionNamesTest.Pages_MessageManagement, L("MessageManagement"));
            ////留言功能
            //var messagefunction = messagemanagement.CreateChildPermission(PermissionNamesTest.Pages_MessageFunction, L("MessageFunction"));
            #endregion
        }

        /// <summary>
        /// 本地化
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyPracticeConsts.LocalizationSourceName);
        }
    }
}
