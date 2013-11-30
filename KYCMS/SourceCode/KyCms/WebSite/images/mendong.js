//<!CDATA[
function g(o){return document.getElementById(o);}
if (document.attachEvent){
  addEvent = function(o,evn,f){o.attachEvent("on"+evn,f)}
}
else if (document.addEventListener){
  addEvent = function(o,evn,f){o.addEventListener(evn,f,false)}
}
/*功能：选项卡*/
 function initTab870(nid,cid,action,defaultIndex){
  var ls = g(nid).getElementsByTagName('li');
  var cc = g(cid).childNodes;
  var c = [];
  var index = defaultIndex?defaultIndex:0;
  for (var i = 0 ; i < cc.length ; i ++)if(cc[i].nodeType==1)c.push(cc[i]);
  if (ls.length!=c.length)
    throw({description:'菜单和内容数量不对应'});
  for (var i = 0 ; i < ls.length ; i ++){
    ls[i].index = i;
    if (i==index){
      ls[i].className = 'hovertab870';
      c[i].className = 'dis'
      ls[i].parentNode.last = ls[i];
    }
    addEvent(ls[i],action,function(e){
      var self = window.event?window.event.srcElement:e?e.target:null;
      if (self.parentNode.last){
        self.parentNode.last.className = 'normaltab870';
        c[self.parentNode.last.index].className = 'undis';
      };
      self.className = 'hovertab870';
      c[self.index].className = 'dis';
      self.parentNode.last = self;
    });
  }
}
function initTab(nid,cid,action,defaultIndex){
  var ls = g(nid).getElementsByTagName('li');
  var cc = g(cid).childNodes;
  var c = [];
  var index = defaultIndex?defaultIndex:0;
  for (var i = 0 ; i < cc.length ; i ++)if(cc[i].nodeType==1)c.push(cc[i]);
  if (ls.length!=c.length)
    throw({description:'菜单和内容数量不对应'});
  for (var i = 0 ; i < ls.length ; i ++){
    ls[i].index = i;
    if (i==index){
      ls[i].className = 'hovertab';
      c[i].className = 'dis'
      ls[i].parentNode.last = ls[i];
    }
    addEvent(ls[i],action,function(e){
      var self = window.event?window.event.srcElement:e?e.target:null;
      if (self.parentNode.last){
        self.parentNode.last.className = 'normaltab';
        c[self.parentNode.last.index].className = 'undis';
      };
      self.className = 'hovertab';
      c[self.index].className = 'dis';
      self.parentNode.last = self;
    });
  }
}
function initTab510(nid,cid,action,defaultIndex){
  var ls = g(nid).getElementsByTagName('li');
  var cc = g(cid).childNodes;
  var c = [];
  var index = defaultIndex?defaultIndex:0;
  for (var i = 0 ; i < cc.length ; i ++)if(cc[i].nodeType==1)c.push(cc[i]);
  if (ls.length!=c.length)
    throw({description:'菜单和内容数量不对应'});
  for (var i = 0 ; i < ls.length ; i ++){
    ls[i].index = i;
    if (i==index){
      ls[i].className = 'hovertab510';
      c[i].className = 'dis'
      ls[i].parentNode.last = ls[i];
    }
    addEvent(ls[i],action,function(e){
      var self = window.event?window.event.srcElement:e?e.target:null;
      if (self.parentNode.last){
        self.parentNode.last.className = 'normaltab510';
        c[self.parentNode.last.index].className = 'undis';
      };
      self.className = 'hovertab510';
      c[self.index].className = 'dis';
      self.parentNode.last = self;
    });
  }
}
function initTab670(nid,cid,action,defaultIndex){
  var ls = g(nid).getElementsByTagName('li');
  var cc = g(cid).childNodes;
  var c = [];
  var index = defaultIndex?defaultIndex:0;
  for (var i = 0 ; i < cc.length ; i ++)if(cc[i].nodeType==1)c.push(cc[i]);
  if (ls.length!=c.length)
    throw({description:'菜单和内容数量不对应'});
  for (var i = 0 ; i < ls.length ; i ++){
    ls[i].index = i;
    if (i==index){
      ls[i].className = 'hovertab670';
      c[i].className = 'dis'
      ls[i].parentNode.last = ls[i];
    }
    addEvent(ls[i],action,function(e){
      var self = window.event?window.event.srcElement:e?e.target:null;
      if (self.parentNode.last){
        self.parentNode.last.className = 'normaltab670';
        c[self.parentNode.last.index].className = 'undis';
      };
      self.className = 'hovertab670';
      c[self.index].className = 'dis';
      self.parentNode.last = self;
    });
  }
}
//]]>