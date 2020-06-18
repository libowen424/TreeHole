import axios from "axios";

export async function getMark(userId) {
    //resp是全部数据
    var sql ="/api/ifo?userId="+0;
    var resp = await axios.get(sql);
    //resp1是当前用户信息
    var sql ="/api/ifo?userId="+userId;
    var resp1 = await axios.get(sql);
    var sql ="/api/concern?userId1="+userId;
    var resp2 = await axios.get(sql);
    console.log(resp2.data);
    var mark=[];

    for(var i =0;i<resp.data.length;i++)
    {
        if(resp.data[i].userId!=userId)
        {
            var grade =0 ;
            var isConcern =false;
            if(resp.data[i].sex==resp1.data[0].sexorien)
            grade+=50;
            if(resp.data[i].profession==resp1.data[0].profession)
            grade+=20;
            for(var j=0;j<5;j++)
            {
                if(resp.data[i].interest.charAt(j)==resp1.data[0].interest.charAt(j))
                {
                    grade+=5;
                }
            }
            for(var k=0;k<resp2.data.length;k++)
            {
                if(resp2.data[k].userId2==resp.data[i].userId)
                {
                    isConcern=true;
                }
            }
            mark.push(
                {mark:grade,
                name:resp.data[i].userName,
                birth:resp.data[i].birth,
                sex:resp.data[i].sex,
                height:resp.data[i].height,
                profession:resp.data[i].profession,
                userId:resp.data[i].userId,
                isConcern:isConcern,
                });
        }
    }
    return mark;
  }

