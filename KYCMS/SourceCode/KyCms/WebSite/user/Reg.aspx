<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reg.aspx.cs" Inherits="user_Reg" %>

<%@ Register Src="../common/Linkage.ascx" TagName="Linkage" TagPrefix="uc2" %>

<%@ Register Src="ps.ascx" TagName="ps" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新用户注册</title>
    <link href="css/Default.css" type="text/css" rel="Stylesheet" />

    <script src="../js/Common.js" type="text/javascript"></script>
    <script src="../js/RiQi.js" type="text/javascript"></script>
    <script src="../js/InfoModel.js" type="text/javascript"></script>

    <script>
    function CheckUserName()
    {
        var UserName=$("txtUsername").value;
        if(UserName=="")
        {
            alert("请输入用户名");
            return false;
        }
        user_Reg.CheckUserName(UserName,Call_Back);
    }
    
    function Call_Back(res)
    {
        alert(res.value);
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table align="center" cellpadding="0" cellspacing="0" height="70" width="99%">
            <tr>
                <td align="left" width="40%">
                    <img src="images/logo.jpg" /></td>
                <td align="center">
                    <img src="images/banner.gif" /></td>
            </tr>
        </table>
        <table align="center" cellpadding="0" cellspacing="0" class="wzdh" width="99%">
            <tr>
                <td width="20">
                    <img align="absMiddle" src="images/skin/default/you.gif" /></td>
                <td>
                    您现在的位置：<asp:TextBox ID="FilePicPath" runat="server" style="display:none" Width="1px">User|0</asp:TextBox><asp:HyperLink ID="hylnkIndex" runat="server">站点首页</asp:HyperLink>
                    &gt;&gt; 新用户注册</td>
                <td align="right" width="50">
                </td>
            </tr>
        </table>
        <table cellpadding="2" cellspacing="1" class="border" width="100%" align="center">
            <tr>
                <td class="title" colspan="2">
                    新用户注册
                    <uc2:Linkage ID="Linkage1" runat="server" />
                </td>
            </tr>
            <tbody id="OnCommon" runat="server">
                <tr>
                    <td class="bqleft" style="width: 120px">
                        用户名：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtUsername" runat="server" MaxLength="20" CssClass="textbox"></asp:TextBox>
                        <input id="Button1" type="button" value="检查用户名是否可用" class="btn" onclick="CheckUserName()" />
                        <br />
                        <span class="tips">4-20 字符</span></td>
                </tr>
                <tr>
                    <td class="bqleft" style="width: 120px">
                        密码：</td>
                    <td class="bqright">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPwd" runat="server" onkeyup="chkPs(this.value);" TextMode="Password"
                                        MaxLength="20" CssClass="textbox"></asp:TextBox>
                                    <font color="red">*</font>&nbsp;&nbsp;</td>
                                <td>
                                    <uc1:ps ID="Ps1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft" style="width: 120px">
                        确认密码：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtCnfmPwd" runat="server" TextMode="Password" MaxLength="20" CssClass="textbox"></asp:TextBox>
                        <font color="red">*</font></td>
                </tr>
                <tr>
                    <td class="bqleft" style="width: 120px">
                        密码提示问题：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtQuestion" runat="server" CssClass="textbox"></asp:TextBox>
                        <font color="red">*</font></td>
                </tr>
                <tr>
                    <td class="bqleft" style="width: 120px">
                        密码提示答案：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtAnswer" runat="server" CssClass="textbox"></asp:TextBox>
                        <font color="red">*</font></td>
                </tr>
                <tr>
                    <td class="bqleft" style="width: 120px">
                        电子邮箱：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="textbox"></asp:TextBox>
                        <font color="red">*</font>
                    </td>
                </tr>
                <tr>
                    <td class="bqleft" style="width: 120px">
                        隐私设定：</td>
                    <td class="bqright">
                        <asp:RadioButtonList ID="txtSecret" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">公开</asp:ListItem>
                            <asp:ListItem Value="0">隐藏</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <asp:Literal ID="ModelHtml" runat="server"></asp:Literal><tr id="Code" runat="server">
                    <td class="bqleft" style="width: 120px">
                        验证码：</td>
                    <td class="bqright">
                        <asp:TextBox ID="txtCode" runat="server" MaxLength="6" CssClass="textbox"></asp:TextBox>
                        <img src="../common/Code.aspx" align="absMiddle" onclick="this.src='../common/code.aspx'"
                            alt="给我换一个" /></td>
                </tr>
                <tr>
                    <td class="bqleft" style="width: 120px">
                    </td>
                    <td class="bqright">
                        <asp:Button ID="txtSubmit" runat="server" Text=" 注 册 " OnClick="txtSubmit_Click"
                            CssClass="btn" />
                        <input id="Reset1" type="reset" value="重置" class="btn" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox ID="chkAgrement" runat="server" Checked="True" Text="我已阅读并同意注册协议" onclick="javascript:$('txtSubmit').disabled=!this.checked">
                        </asp:CheckBox><a href="license.htm" target="_blank">查看协议</a></td>
                </tr>
            </tbody>
            <tbody id="OnNull" runat="server" align="center">
                <tr>
                    <td colspan="2">
                        <textarea id="TextAreaLicense" style="width: 683px; height: 299px"> 
                    会 员 注 册 协 议 
              
一、服务条款的确认和接纳
    本站保留各项服务的所有权和运作权。本站提供的服务将完全按照其发布的章程、服务条款和操作规则严格执行。会员必须完全同意所有服务条款并完成注册
程序，才能成为本站的正式注册会员享受本站提供的更全面的服务。

二、权利及义务
    本站的权利、义务：
1、尊重会员隐私制度
　 尊重会员个人隐私是本站的基本政策，本站不会公开、编辑或透露会员的注册资料，除非符合以下情况： 
   (1) 根据中华人民共和国国家安全机构、公安部门的要求及根据相应的法律程序要求。
   (2) 维护本站的商标所有权及其它权益。
   (3) 在紧急情况下竭力维护会员个人、其它社会个体和社会大众的安全。
   (4) 符合其他相关的要求。
   如果会员提供的资料包含有不正确的信息，本站保留结束会员使用网络服务资格的权利。
2、服务内容的所有权
   本站定义的服务内容包括：文字、软件、声音、图片、录象、图表、广告中的全部内容；本站为会员提供的其他信息。所有这些内容受版权、商标及其它财产
所有权法律的保护。所以，会员只能在本站和广告商授权下才能使用这些内容，而不能擅自复制、再造这些内容、或创造与内容有关的派生产品。任何人需要转载
本站的文章、数据，必须征得原文作者或本站授权。
3、会员管理
   本站对会员的管理依据国家法律、地方法律和国际法律等标准。
4、对会员信息的存储和限制
   本站不对会员所发布信息的删除或储存失败负责。本站有判定会员的行为是否符合本站服务条款的要求和精神的保留权利，如果会员违背了服务条款的规定，
本站有权选择适当的处理方法直至中断对其提供网络服务的权利。

会员权利义务：
1、会员必须遵循：
　　(1)从中国境内向外或从中国境外向内传输资料时必须符合中国有关法规。
　　(2)使用网络服务不作非法用途。
　　(3)不干扰或混乱网络服务。
　　(4)遵守所有使用网络服务的网络协议、规定、程序和惯例。
   同时会员承诺：
   (1)不传输任何非法的、骚扰性的、中伤他人的、辱骂性的、恐吓性的、伤害性的、庸俗的，淫秽等信息资料；
   (2)不传输任何教唆他人构成犯罪行为的资料；
   (3) 不传输任何不符合当地法规、国家法律和国际法律的资料；
   (4) 未经许可而非法进入其它电脑系统是禁止的；
   (5) 法律规定的其他义务。
   若会员的行为不符合以上提到的服务条款，本站将作出独立判断立即取消会员服务帐号。会员需对自己在网上的行为承担法律责任。会员若在本站上散布和传
播反动、色情或其他违反中国法律的信息，本站的系统记录有可能作为会员违反法律的证据。
2、基于网络服务的特性及重要性，会员同意：
　　(1)提供详尽、准确的个人资料。
　　(2)不断更新注册资料，符合及时、详尽、准确的要求。
　　(3)自行配备上网的所需设备， 包括个人电脑、调制解调器或其他必备上网装置。
　　(4)自行负担个人上网所支付的与此服务有关的电话费用、 网络费用。
3、会员的帐号、密码和安全性 
   会员一旦注册成功，成为本站的合法会员，将得到一个密码和会员名。会员对自己的会员名、密码和安全将负全部责任。另外，每个会员都要对以其会员名进
行的所有活动和事件负全责。
   会员同意若发现任何非法使用该用户名或其它有损用户利益的情况，立即通告本站。本站在应用户要求并且确认用户个人信息的情况下，可以对用户密码进行
更改并及时通知用户。
4、会员发布宣传及广告信息
   会员在他们发表的信息中加入宣传资料或参与广告策划，在本站的免费服务上展示他们的作品或商品，任何这类促销方法，包括运输货物、付款、服务、商业
条件、担保及与广告有关的描述都只是在相应的会员和广告销售商之间发生。本站不承担任何责任，本站没有义务为这类广告销售负任何一部分的责任。会员需要
对此承担全部责任。
5、会员同意保障和维护本站全体成员的利益，负责支付由会员使用超出服务范围引起的律师费用，违反服务条款的损害补偿费用等。

三、关于担保 
　　本站明确表示不作任何类型的担保，不论是明确的或隐含的，但是不对商业性的隐含担保、特定目的和不违反规定的适当担保作限制。本站不担保服务一定能
满足会员的要求，也不担保服务不会受中断，对服务的及时性，安全性，出错发生都不作担保。本站拒绝提供任何担保，由会员自己承担系统受损或资料丢失的所
有风险和责任。本站对在互联网上得到的任何商品购物服务或交易进程，都不作担保。会员不会从本站收到口头或书面的意见或信息，也不会在这里作明确担保。

四、关于责任
    本站对任何直接、间接、偶然、特殊及继起的损害不负责任，这些损害可能来自：他人的行为、会员不正当使用网络服务，在网上购买商品或进行同类型服务
，在网上进行交易，非法使用网络服务或用户传送的信息有所变动。这些行为都有可能会导致本站的形象受损，所以本站事先提出这种损害的可能性。
　　会员同意保障和维护本站全体会员和本站的利益，承担由会员行为导致的一切后果损失。

五、服务条款的修改和服务修订
本站有权在必要时修改服务条款，本站服务条款一旦发生变动，将会在重要页面上提示修改内容。如果不同意所改动的内容，会员可以主动取消获得的网络服务并
及时通知本站。如果会员继续享用网络服务，则视为接受服务条款的变动。本站保留随时修改而不需知照用户的权利。

六、通告
    所有发给会员的通告都可通过重要页面的公告或电子邮件或常规的信件传送。服务条款的修改、服务变更、或其它重要事件的通告都会以此形式进行。

七、终止服务
    会员或本站可随时根据实际情况中断一项或多项网络服务。会员对后来的条款修改有异议，或对本站的服务不满，可以行使如下权利：
　　(1)停止使用本站的网络服务。
　　(2)通告本站停止对该会员的服务。
    结束会员服务后，会员使用网络服务的权利马上中止。从那时起，用户没有权利，本站也没有义务传送任何未处理的信息或未完成的服务给用户或第三方。遗
留问题由双方协商解决。

八、法律管辖
    网络服务条款要与中华人民共和国的法律解释相一致，会员和本站一致同意服从中国法院管辖。如发生本站服务条款与中华人民共和国法律相抵触时，则这些
条款将完全按法律规定重新解释，而其它条款则依旧保持对会员产生法律效力和影响。

</textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td rowspan="2" valign="top">
                                    <img src="../user/images/userreg.jpg" /></td>
                                <td style="width: 4px">
                                </td>
                                <td style="width: 100px">
                                    请选择注册类型：</td>
                            </tr>
                            <tr>
                                <td style="width: 20px">
                                </td>
                                <td>
                                    <asp:Repeater ID="rptGroup" runat="server">
                                        <ItemTemplate>
                                            ·<a href='?TypeId=<%#Eval("Id") %><%#returnUrl1 %>'><strong><%#Eval("Name")%></strong></a>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
