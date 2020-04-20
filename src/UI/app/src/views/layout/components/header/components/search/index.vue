<template>
  <section class="header-search">
    <i class="el-icon-search" />
    <input type="search" placeholder="搜一下，有你想要~" />
  </section>
</template>
<script>
export default {}
</script>
<style lang="scss">
.header-search {
  position: relative;
  width: 600px;
  border-right: solid 1px #e9ecee;
  border-left: solid 1px #e9ecee;
  box-sizing: border-box;
  padding: 20px 20px 20px 50px;

  > .el-icon-search {
    position: absolute;
    top: 25px;
    left: 10px;
    font-size: 30px;
    color: #93969a;
  }

  input {
    display: block;
    border: none;
    height: 42px;
    width: 100%;
    color: #555;
    font-size: 20px;
    outline-color: #fff;
  }
}
</style>
