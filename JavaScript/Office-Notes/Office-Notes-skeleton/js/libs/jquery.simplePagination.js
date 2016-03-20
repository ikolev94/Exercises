/**
* simplePagination.js v1.6
* A simple jQuery pagination plugin.
* http://flaviusmatis.github.com/simplePagination.js/
*
* Copyright 2012, Flavius Matis
* Released under the MIT license.
* http://flaviusmatis.github.com/license.html
*/
!function(e){var a={init:function(t){var s=e.extend({items:1,itemsOnPage:1,pages:0,displayedPages:5,edges:2,currentPage:0,hrefTextSuffix:"",prevText:"Prev",nextText:"Next",ellipseText:"&hellip;",cssStyle:"light-theme",labelMap:[],selectOnClick:!0,nextAtFront:!1,invertPageOrder:!1,useStartEdge:!0,useEndEdge:!0,onPageClick:function(e,a){},onInit:function(){}},t||{}),n=this;return s.pages=s.pages?s.pages:Math.ceil(s.items/s.itemsOnPage)?Math.ceil(s.items/s.itemsOnPage):1,s.currentPage?s.currentPage=s.currentPage-1:s.currentPage=s.invertPageOrder?s.pages-1:0,s.halfDisplayed=s.displayedPages/2,this.each(function(){n.addClass(s.cssStyle+" simple-pagination").data("pagination",s),a._draw.call(n)}),s.onInit(),this},selectPage:function(e){return a._selectPage.call(this,e-1),this},prevPage:function(){var e=this.data("pagination");return e.invertPageOrder?e.currentPage<e.pages-1&&a._selectPage.call(this,e.currentPage+1):e.currentPage>0&&a._selectPage.call(this,e.currentPage-1),this},nextPage:function(){var e=this.data("pagination");return e.invertPageOrder?e.currentPage>0&&a._selectPage.call(this,e.currentPage-1):e.currentPage<e.pages-1&&a._selectPage.call(this,e.currentPage+1),this},getPagesCount:function(){return this.data("pagination").pages},getCurrentPage:function(){return this.data("pagination").currentPage+1},destroy:function(){return this.empty(),this},drawPage:function(e){var t=this.data("pagination");return t.currentPage=e-1,this.data("pagination",t),a._draw.call(this),this},redraw:function(){return a._draw.call(this),this},disable:function(){var e=this.data("pagination");return e.disabled=!0,this.data("pagination",e),a._draw.call(this),this},enable:function(){var e=this.data("pagination");return e.disabled=!1,this.data("pagination",e),a._draw.call(this),this},updateItems:function(e){var t=this.data("pagination");t.items=e,t.pages=a._getPages(t),this.data("pagination",t),a._draw.call(this)},updateItemsOnPage:function(e){var t=this.data("pagination");return t.itemsOnPage=e,t.pages=a._getPages(t),this.data("pagination",t),a._selectPage.call(this,0),this},_draw:function(){var t,s,n=this.data("pagination"),i=a._getInterval(n);a.destroy.call(this),s="function"==typeof this.prop?this.prop("tagName"):this.attr("tagName");var r="UL"===s?this:e("<ul></ul>").appendTo(this);if(n.prevText&&a._appendItem.call(this,n.invertPageOrder?n.currentPage+1:n.currentPage-1,{text:n.prevText,classes:"prev"}),n.nextText&&n.nextAtFront&&a._appendItem.call(this,n.invertPageOrder?n.currentPage-1:n.currentPage+1,{text:n.nextText,classes:"next"}),n.invertPageOrder){if(i.end<n.pages&&n.edges>0){if(n.useStartEdge){var l=Math.max(n.pages-n.edges,i.end);for(t=n.pages-1;t>=l;t--)a._appendItem.call(this,t)}n.pages-n.edges>i.end&&n.pages-n.edges-i.end!=1?r.append('<li class="disabled"><span class="ellipse">'+n.ellipseText+"</span></li>"):n.pages-n.edges-i.end==1&&a._appendItem.call(this,i.end)}}else if(i.start>0&&n.edges>0){if(n.useStartEdge){var g=Math.min(n.edges,i.start);for(t=0;g>t;t++)a._appendItem.call(this,t)}n.edges<i.start&&i.start-n.edges!=1?r.append('<li class="disabled"><span class="ellipse">'+n.ellipseText+"</span></li>"):i.start-n.edges==1&&a._appendItem.call(this,n.edges)}if(n.invertPageOrder)for(t=i.end-1;t>=i.start;t--)a._appendItem.call(this,t);else for(t=i.start;t<i.end;t++)a._appendItem.call(this,t);if(n.invertPageOrder){if(i.start>0&&n.edges>0&&(n.edges<i.start&&i.start-n.edges!=1?r.append('<li class="disabled"><span class="ellipse">'+n.ellipseText+"</span></li>"):i.start-n.edges==1&&a._appendItem.call(this,n.edges),n.useEndEdge)){var g=Math.min(n.edges,i.start);for(t=g-1;t>=0;t--)a._appendItem.call(this,t)}}else if(i.end<n.pages&&n.edges>0&&(n.pages-n.edges>i.end&&n.pages-n.edges-i.end!=1?r.append('<li class="disabled"><span class="ellipse">'+n.ellipseText+"</span></li>"):n.pages-n.edges-i.end==1&&a._appendItem.call(this,i.end),n.useEndEdge)){var l=Math.max(n.pages-n.edges,i.end);for(t=l;t<n.pages;t++)a._appendItem.call(this,t)}n.nextText&&!n.nextAtFront&&a._appendItem.call(this,n.invertPageOrder?n.currentPage-1:n.currentPage+1,{text:n.nextText,classes:"next"})},_getPages:function(e){var a=Math.ceil(e.items/e.itemsOnPage);return a||1},_getInterval:function(e){return{start:Math.ceil(e.currentPage>e.halfDisplayed?Math.max(Math.min(e.currentPage-e.halfDisplayed,e.pages-e.displayedPages),0):0),end:Math.ceil(e.currentPage>e.halfDisplayed?Math.min(e.currentPage+e.halfDisplayed,e.pages):Math.min(e.displayedPages,e.pages))}},_appendItem:function(t,s){var n,i,r=this,l=r.data("pagination"),g=e("<li></li>"),d=r.find("ul");t=0>t?0:t<l.pages?t:l.pages-1,n={text:t+1,classes:""},l.labelMap.length&&l.labelMap[t]&&(n.text=l.labelMap[t]),n=e.extend(n,s||{}),t==l.currentPage||l.disabled?(l.disabled?g.addClass("disabled"):g.addClass("active"),i=e('<span class="current">'+n.text+"</span>")):(i=e('<a href="'+l.hrefTextPrefix+(t+1)+l.hrefTextSuffix+'" class="page-link">'+n.text+"</a>"),i.click(function(e){return a._selectPage.call(r,t,e)})),n.classes&&i.addClass(n.classes),g.append(i),d.length?d.append(g):r.append(g)},_selectPage:function(e,t){var s=this.data("pagination");return s.currentPage=e,s.selectOnClick&&a._draw.call(this),s.onPageClick(e+1,t)}};e.fn.pagination=function(t){return a[t]&&"_"!=t.charAt(0)?a[t].apply(this,Array.prototype.slice.call(arguments,1)):"object"!=typeof t&&t?void e.error("Method "+t+" does not exist on jQuery.pagination"):a.init.apply(this,arguments)}}(jQuery);