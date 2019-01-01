using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sample06
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //增
            //test_insert();
            //test_mult_insert();
            //test_insert_comment();
            //删
            //test_del();
            //test_mul_del();
            //改
            //test_update();
            //查
            //test_select_one();//单条
            //test_select_list();//多条

            //多表查询
            test_select_content_with_comment();
            Console.Read();
        }

        static void test_insert()
        {
            var content = new Content()
            {
                content="content1",
                title="title1"
            };
            using (var conn = new SqlConnection("Data Source=DESKTOP-7GCN8DV\\SQL2014;User Id=sa;Password=sa1234;Initial Catalog=Sample06;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"insert into [Content] (title,[content],status,add_time,modify_time) values (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert:插入了{result}条数据!");
            }
        }

        static void test_mult_insert()
        {
            List<Content> contents = new List<Content>()
            {
                new Content(){ title="title_mult_1",content="content_mult_1"},
                new Content(){ title="title_mult_2",content="content_mult_2"}
            };
            using (var conn = new SqlConnection("Data Source=DESKTOP-7GCN8DV\\SQL2014;User Id=sa;Password=sa1234;Initial Catalog=Sample06;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"insert into [Content] (title,[content],status,add_time,modify_time) values (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_insert:插入了{result}条数据!");
            }
        }

        static void test_del()
        {
            var content = new Content()
            {
                id = 2
            };
            using (var conn=new SqlConnection("Data Source=DESKTOP-7GCN8DV\\SQL2014;User Id=sa;Password=sa1234;Initial Catalog=Sample06;Pooling=true;Max Pool Size=100;"))
            {
                string sql_del = @"delete from [content] where id=@id";
                var result = conn.Execute(sql_del, content);
                Console.WriteLine($"test_del:删除了{result}条数据");
            }
        }

        static void test_mul_del()
        {
            List<Content> contents = new List<Content>()
            {
                new Content{ id=1},
                new Content { id=3}
            };

            using (var conn = new SqlConnection("Data Source=DESKTOP-7GCN8DV\\SQL2014;User Id=sa;Password=sa1234;Initial Catalog=Sample06;Pooling=true;Max Pool Size=100;"))
            {
                string sql_del = @"delete from [content] where id=@id";
                var result = conn.Execute(sql_del, contents);
                Console.WriteLine($"test_del:删除了{result}条数据");
            }
        }

        static void test_update()
        {
            var content = new Content()
            {
                id = 4,
                title="title_update4",
                content="title_update4"
            };
            using (var conn=new SqlConnection("Data Source=DESKTOP-7GCN8DV\\SQL2014;User Id=sa;Password=sa1234;Initial Catalog=Sample06;Pooling=true;Max Pool Size=100"))
            {
                var sql_update = @"update [Content]  set title=@title ,[content]=@content,modify_time=getdate() where id=@id";
                var result = conn.Execute(sql_update, content);
                Console.WriteLine($"test_uplate:更新了{result}条数据");

            }
        }

        static void test_select_one()
        {
            using (var conn = new SqlConnection("Data Source=DESKTOP-7GCN8DV\\SQL2014;User Id=sa;Password=sa1234;Initial Catalog=Sample06;Pooling=true;Max Pool Size=100;"))
            {
                string sql_query = @"select * from [content] where id=@id";
                var result = conn.QueryFirstOrDefault<Content>(sql_query, new { id = 5 });//实体对象
                Console.WriteLine($"test_select_one:查到的数据为{result.title}");
            }
        }

        static void test_select_list()
        {
            using (var conn = new SqlConnection("Data Source=DESKTOP-7GCN8DV\\SQL2014;User Id=sa;Password=sa1234;Initial Catalog=Sample06;Pooling=true;Max Pool Size=100"))
            {
                string sql_select_list = @"select * from [dbo].[content] where id in @ids";
                var result = conn.Query<Content>(sql_select_list, new { ids = new int[] { 5, 6 } });
                Console.WriteLine($"test_select_one：查到的数据为{result.AsList()[1].title}：");
            }
        }

        static void test_insert_comment()
        {
            var comment = new Comment()
            {
                content_id = 4,
                content = "评论111111",
                add_time = DateTime.Now
            };
            using (var conn = new SqlConnection("Data Source=DESKTOP-7GCN8DV\\SQL2014;User Id=sa;Password=sa1234;Initial Catalog=Sample06;Pooling=true;Max Pool Size=100"))
            {
                string sql_insert_comment = @"insert into comment (content_id,content,add_time) values(@content_id,@content,@add_time)";
                var result = conn.Execute(sql_insert_comment, comment);
                Console.WriteLine($"插入评论数据{result}条");
            }
        }

        static void test_select_content_with_comment()
        {
            using (var conn = new SqlConnection("Data Source=DESKTOP-7GCN8DV\\SQL2014;User Id=sa;Password=sa1234;Initial Catalog=Sample06;Pooling=true;Max Pool Size=100"))
            {
                string sql_mult_select = @"select * from [content] where id=@id;select * from comment where content_id=@id";
                using (var result=conn.QueryMultiple(sql_mult_select,new { id = 4 }))
                {
                    var content = result.ReadFirstOrDefault<ContentWithComment>();
                    content.comments = result.Read<Comment>();
                    Console.WriteLine($"test_select_content_with_comment:内容4的评论数量{content.comments.AsList().Count}");
                }
            }
        }

    }
}
