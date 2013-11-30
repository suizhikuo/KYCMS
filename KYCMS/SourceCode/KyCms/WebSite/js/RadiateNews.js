// JScript 文件
// ------ 定义全局变量
       var theNewsNum;
	   var theAddNum;
	   var totalNum;
	   var CurrentPosion=0;
       var theCurrentNews;
       var theCurrentLength;
       var theNewsText;
       var theTargetLink;
       var theCharacterTimeout;
       var theNewsTimeout;
       var theBrowserVersion;
       var theWidgetOne;
       var theWidgetTwo;
       var theSpaceFiller;
       var theLeadString;
       var theNewsState;
       
       function startTicker()
       {               
        // ------ 设置初始数值
          theCharacterTimeout = 50;//字符间隔时间
          theNewsTimeout    = 2000;//文章间隔时间
          theWidgetOne      =  "_";//文章前面下标符1
          theWidgetTwo      =  "-";//文章前面下标符
          theNewsState      = 1;
          //theNewsNum      = document.body.children.incoming.children.NewsNum.innerText;//文章总条数
          //add by lin
		  theNewsNum        = document.getElementById("incoming").children.AllNews.children.length;//文章总条数
		  theAddNum         = document.getElementById("incoming").children.AddNews.children.length;//补充条数
		  totalNum          =theNewsNum+theAddNum;
		  theCurrentNews    = 0;
          theCurrentLength  = 0;
          theLeadString     = " ";
          theSpaceFiller    = " ";
          runTheTicker();
       }
        // --- 基础函数
       function runTheTicker()
       {
          if(theNewsState == 1)
          {
            if(CurrentPosion<theNewsNum)
            { 
			    setupNextNews();
            }
			else
			{
				 setupAddNews();
			}
			CurrentPosion++;
		    if(CurrentPosion>=totalNum||CurrentPosion>=5) CurrentPosion=0;  //最多条数不超过5条
		}
        if(theCurrentLength != theNewsText.length)
        {
             drawNews();
        }
        else
        {
            closeOutNews();
        }
      }
// --- 跳转下一条文章
       function setupNextNews()
       {
          theNewsState = 0;
		  theCurrentNews = theCurrentNews % theNewsNum;     
          theNewsText = document.getElementById("AllNews").children[theCurrentNews].children.Summary.innerText;
          theTargetLink = document.getElementById("AllNews").children[theCurrentNews].children.NewsLink.innerText;          
          theCurrentLength = 0;
          document.all.hottext.href = theTargetLink;
          theCurrentNews++;
	   }
       function setupAddNews()
       {
          theNewsState = 0;
		  theCurrentNews = theCurrentNews % theAddNum;     
          theNewsText = document.getElementById("incoming").children.AddNews.children[theCurrentNews].children.Summary.innerText;
          theTargetLink = document.getElementById("incoming").children.AddNews.children[theCurrentNews].children.NewsLink.innerText;          
          theCurrentLength = 0;
          document.all.hottext.href = theTargetLink;
          theCurrentNews++;
	   }			 
// --- 滚动文章
       function drawNews()
       {
          var myWidget;       
          if((theCurrentLength % 2) == 1)
          {
             myWidget = theWidgetOne;
          }
          else
          {
             myWidget = theWidgetTwo;
          }
          document.all.hottext.innerHTML = theLeadString + theNewsText.substring(0,theCurrentLength) + myWidget + theSpaceFiller;
          theCurrentLength++;
          setTimeout("runTheTicker()", theCharacterTimeout);
       }
// --- 结束文章循环
       function closeOutNews()
       {
          document.all.hottext.innerHTML = theLeadString + theNewsText + theSpaceFiller;
          theNewsState = 1;
          setTimeout("runTheTicker()", theNewsTimeout);
       }
          
window.onload=startTicker; 