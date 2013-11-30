using System;
using System.Reflection;
using Ky.Common;
namespace Ky.DALFactory
{


    public sealed class DataAccess
    {
        private static readonly string path = Param.Path;

        private DataAccess()
        {
        }

        public static ILbCategory CareateLbCategory()
        {
            string typeName = path + ".LbCategory";
            return (ILbCategory) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ICreate Create()
        {
            string typeName = path + ".Create";
            return (ICreate) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IAd CreateAd()
        {
            string typeName = path + ".Ad";
            return (IAd) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IAdCategory CreateAdCategory()
        {
            string typeName = path + ".AdCategory";
            return (IAdCategory) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IAdmin CreateAdmin()
        {
            string typeName = path + ".Admin";
            return (IAdmin) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IAnomaly CreateAnomaly()
        {
            string typeName = path + ".Anomaly";
            return (IAnomaly) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IArticle CreateArticle()
        {
            string typeName = path + ".Article";
            return (IArticle) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ICard CreateCard()
        {
            string typeName = path + ".Card";
            return (ICard) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IChannel CreateChannel()
        {
            string typeName = path + ".Channel";
            return (IChannel) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ICollection CreateCollection()
        {
            string typeName = path + ".Collection";
            return (ICollection) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ICollectionAddress CreateCollectionAddress()
        {
            string typeName = path + ".CollectionAddress";
            return (ICollectionAddress) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IColumn CreateColumn()
        {
            string typeName = path + ".Column";
            return (IColumn) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IKyCommon CreateCommon()
        {
            string typeName = path + ".KyCommon";
            return (IKyCommon) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IController CreateController()
        {
            string typeName = path + ".Controller";
            return (IController) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ICustomForm CreateCustomForm()
        {
            string typeName = path + ".CommonModel.CustomForm";
            return (ICustomForm) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ICustomFormField CreateCustomFormField()
        {
            string typeName = path + ".CommonModel.CustomFormField";
            return (ICustomFormField) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IDictionary CreateDictionary()
        {
            string typeName = path + ".Dictionary";
            return (IDictionary) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IDownLoad CreateDownload()
        {
            string typeName = path + ".DownLoad";
            return (IDownLoad) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IDownLoadAddress CreateDownLoadAddress()
        {
            string typeName = path + ".DownLoadAddress";
            return (IDownLoadAddress) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IDownLoadServer CreateDownServer()
        {
            string typeName = path + ".DownLoadServer";
            return (IDownLoadServer) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IEnterprise CreateEnterprise()
        {
            string typeName = path + ".Enterprise";
            return (IEnterprise) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IFeedback CreateFeedback()
        {
            string typeName = path + ".Feedback";
            return (IFeedback) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IGroup CreateGroup()
        {
            string typeName = path + ".Group";
            return (IGroup) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IImage CreateImage()
        {
            string typeName = path + ".Image";
            return (IImage) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IInfoModel CreateInfoModel()
        {
            string typeName = path + ".CommonModel.InfoModel";
            return (IInfoModel) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IInfoOper CreateInfoOper()
        {
            string typeName = path + ".InfoOper";
            return (IInfoOper) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ILabelContent CreateLabelContent()
        {
            string typeName = path + ".LabelContent";
            return (ILabelContent) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ILink CreateLink()
        {
            string typeName = path + ".Link";
            return (ILink) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ILog CreateLog()
        {
            string typeName = path + ".Log";
            return (ILog) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IModelField CreateModelField()
        {
            string typeName = path + ".CommonModel.ModelField";
            return (IModelField) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IMoney CreateMoney()
        {
            string typeName = path + ".Money";
            return (IMoney) Assembly.Load(path).CreateInstance(typeName);
        }

        public static INotice CreateNotice()
        {
            string typeName = path + ".Notice";
            return (INotice) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IPowerColumn CreatePowerColumn()
        {
            string typeName = path + ".PowerColumn";
            return (IPowerColumn) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IPowerGroup CreatePowerGroup()
        {
            string typeName = path + ".PowerGroup";
            return (IPowerGroup) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IReport CreateReport()
        {
            string typeName = path + ".Report";
            return (IReport) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IReview CreateReview()
        {
            string typeName = path + ".Review";
            return (IReview) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ISinglePage CreateSinglePage()
        {
            string typeName = path + ".SinglePage";
            return (ISinglePage) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ISiteCount CreateSiteCount()
        {
            string typeName = path + ".SiteCount";
            return (ISiteCount) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ISpecial CreateSpeciall()
        {
            string typeName = path + ".Special";
            return (ISpecial) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IStyle CreateStyle()
        {
            string typeName = path + ".StyleManager";
            return (IStyle) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IStyleCategory CreateStyleCategory()
        {
            string typeName = path + ".StyleCategory";
            return (IStyleCategory) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ISuperior CreateSuperior()
        {
            string typeName = path + ".Superior";
            return (ISuperior) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ISuperLabel CreateSuperLabel()
        {
            string typeName = path + ".CommonModel.SuperLabel";
            return (ISuperLabel) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ITag CreateTag()
        {
            string typeName = path + ".Tag";
            return (ITag) Assembly.Load(path).CreateInstance(typeName);
        }

        public static ITagCategory CreateTagCategory()
        {
            string typeName = path + ".TagCategory";
            return (ITagCategory) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IUser CreateUser()
        {
            string typeName = path + ".User";
            return (IUser) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IUserAlbum CreateUserAlbum()
        {
            string typeName = path + ".UserAlbum";
            return (IUserAlbum) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IUserFavorite CreateUserFavorite()
        {
            string typeName = path + ".UserFavorite";
            return (IUserFavorite) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IUserGroup CreateUserGroup()
        {
            string typeName = path + ".UserGroup";
            return (IUserGroup) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IUserGroupModel CreateUserGroupModel()
        {
            string typeName = path + ".CommonModel.UserGroupModel";
            return (IUserGroupModel) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IUserGroupModelField CreateUserGroupModelField()
        {
            string typeName = path + ".CommonModel.UserGroupModelField";
            return (IUserGroupModelField) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IUserLog CreateUserLog()
        {
            string typeName = path + ".UserLog";
            return (IUserLog) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IUserMessage CreateUserMessage()
        {
            string typeName = path + ".UserMessage";
            return (IUserMessage) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IUserPhoto CreateUserPhoto()
        {
            string typeName = path + ".UserPhoto";
            return (IUserPhoto) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IUserSpace CreateUserSpace()
        {
            string typeName = path + ".UserSpace";
            return (IUserSpace) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IViewLog CreateViewLog()
        {
            string typeName = path + ".ViewLog";
            return (IViewLog) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IVote CreateVote()
        {
            string typeName = path + ".Vote";
            return (IVote) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IVoteCategory CreateVoteCat()
        {
            string typeName = path + ".VoteCategory";
            return (IVoteCategory) Assembly.Load(path).CreateInstance(typeName);
        }

        public static IWebMessage CreateWebMessage()
        {
            string typeName = path + ".WebMessage";
            return (IWebMessage) Assembly.Load(path).CreateInstance(typeName);
        }
    }
}

