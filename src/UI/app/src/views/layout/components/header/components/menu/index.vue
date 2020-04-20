<template>
  <section class="header-menu">
    <el-dropdown trigger="click">
      <div class="header-menu-text">站点导航<i class="el-icon-menu"></i></div>
      <el-dropdown-menu slot="dropdown" class="header-menu-dropdown">
        <div class="header-menu-nav">
          <ul>
            <li>
              <a href=""> <nm-icon name="question" />问题</a>
            </li>
            <li>
              <a href=""> <nm-icon name="notice" />公告</a>
            </li>
            <li>
              <a href=""> <nm-icon name="news" />动态</a>
            </li>
            <li>
              <a href=""> <nm-icon name="suggest" />建议</a>
            </li>
            <li>
              <a href=""> <nm-icon name="news" />文档</a>
            </li>
            <li>
              <a href=""> <nm-icon name="suggest" />日志</a>
            </li>
          </ul>
        </div>
        <div class="header-menu-categories">
          <h3>主题分类</h3>
          <ul>
            <li>
              <a href=""><i style="background-color: #f9bc64;"></i>.Net Core</a>
            </li>
            <li>
              <a href=""><i style="background-color: #3ebafa;"></i>Vue.js</a>
            </li>
            <li>
              <a href=""><i style="background-color: #348aa7;"></i>SqlServer</a>
            </li>
            <li>
              <a href=""><i style="background-color: #5dd39e;"></i>MySql</a>
            </li>
            <li>
              <a href=""><i style="background-color: #ff755a;"></i>Linux</a>
            </li>
            <li>
              <a href=""><i style="background-color: #a7cdbd;"></i>HTML5</a>
            </li>
          </ul>
        </div>
        <div class="header-menu-links">
          <ul>
            <li>
              <a href="">GitHub</a>
            </li>
            <li>
              <a href="">Gitee</a>
            </li>
          </ul>
        </div>
      </el-dropdown-menu>
    </el-dropdown>
  </section>
</template>
<style lang="scss">
.header-menu {
  padding: 0 30px;

  &-text {
    user-select: none;
    &:focus {
      outline-width: 0;
    }
    .el-icon-menu {
      position: relative;
      top: 5px;
      margin-left: 5px;
      font-size: 30px;
      cursor: pointer;

      &:hover,
      &:active {
        color: #f9bc64;
      }
    }
  }
}

.header-menu-dropdown {
  top: 70px !important;
  margin-right: -278px;
  width: 400px;
  border-top: 1px solid #f9bc64;
  box-sizing: border-box;
  border-radius: 0;

  .popper__arrow {
    display: none;
  }

  a {
    text-decoration: none;
    color: #777;
    transition: color 0.4s;

    &.link {
      color: #777;
    }
    &:hover {
      color: #f9bc64;
    }
  }

  li {
    margin-bottom: 7px;
    display: inline-block;
    width: 50%;
    line-height: 28px;
  }

  > div {
    padding: 10px 20px;
  }

  .header-menu-nav {
    li {
      margin-bottom: 0;
      width: 33.3333333333%;
    }
    a {
      position: relative;
      display: inline-block;
      margin: 1%;
      padding: 7px 7px 7px 56px;
      width: 98%;
      box-sizing: border-box;
      border: 1px solid #f2f2f2;

      .nm-icon {
        position: absolute;
        left: 10px;
        top: 2px;
        font-size: 35px;
      }
    }
  }

  .header-menu-categories {
    border-top: 1px solid #e9ecee;
    border-bottom: 1px solid #e9ecee;

    > h3 {
      margin: 6px 0 15px;
      font-size: 14px;
    }

    i {
      display: inline-block;
      margin-right: 10px;
      width: 8px;
      height: 8px;
      border-radius: 50%;
    }
  }

  .header-menu-links {
  }
}
</style>
