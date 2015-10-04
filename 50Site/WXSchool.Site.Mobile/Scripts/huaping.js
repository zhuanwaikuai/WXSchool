
!(function (window, document)
{
    var wrapper = document.querySelector(".content");
    var pages = [].slice.call(document.querySelectorAll(".page"));
    var len = pages.length;
    var logIndex = [len - 1, 0, 1];
    var height = wrapper.clientHeight;
    var time = 300;
    var snapThreshold = 50;
    var loop = false;//是否循环
    var startY, endY;
    var isMove = false;

    var jian = document.querySelector(".jian");
    init();

    document.querySelector(".mbtn").addEventListener("click", function ()
    {
        alert("s");
    }, false);



    function init()
    {
        logIndex.forEach(function (n, i)
        {
            css(pages[n], (i - 1) * height, 0);
        });
        wrapper.addEventListener("touchstart", start, false);
        wrapper.addEventListener("touchmove", move, false);
        wrapper.addEventListener("touchend", end, false);
    }

    //手指按下
    function start(e)
    {
        height = wrapper.clientHeight;
        startY = e.touches[0].pageY;
    }

    //手指移动
    function move(e)
    {
        e.preventDefault();
    }

    //手指离开
    function end(e)
    {
        endY = e.changedTouches[0].pageY;
        var tempDist = endY - startY,
            direction = tempDist < 0 ? 1 : -1;//滑动方向 1:上  -1:下 0:回弹
        if (Math.abs(tempDist) < snapThreshold) { direction = 0; }
        if (!loop && ((logIndex[1] == len - 1 && direction == 1) || (logIndex[1] == 0 && direction == -1))) { return; }
        animate(direction);
    }

    //滑动
    function animate(direction)
    {
        var k;//需要预加载的索引
        if (direction === 1)//上
        {
            logIndex.shift();
            logIndex.push(resetIndex(logIndex[1] + 1));
            k = logIndex[2];
        }
        else if (direction === -1) //下
        {
            logIndex.pop();
            logIndex.unshift(resetIndex(logIndex[0] - 1));
            k = logIndex[0];
        }
        logIndex.forEach(function (n, i)
        {
            css(pages[n], (i - 1) * height, n === k ? 0 : time);
        });

        window.setTimeout(function ()
        {
            jian.style.display = (logIndex[1] == len - 1) ? "none" : "block";
        }, time);
    }

    //css移动
    function css(el, dist, time)
    {
        el.style.transform = el.style.webkitTransform = "translate3d(0," + dist + "px,0)";
        el.style.transition = el.style.webkitTransition = time + "ms";
    }

    //重置index
    function resetIndex(index)
    {
        return (index % len + len) % len;
    }




})(window, document);