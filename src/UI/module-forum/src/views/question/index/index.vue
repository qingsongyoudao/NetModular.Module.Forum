<template>
  <nm-container>
    <nm-list ref="list" v-bind="list">
      <!--查询条件-->
      <template v-slot:querybar>
        <el-form-item label="标题：" prop="title">
          <el-input v-model="list.model.title" clearable />
        </el-form-item>
        <el-form-item label="分类编号：" prop="categoryId">
          <el-input v-model="list.model.categoryId" clearable />
        </el-form-item>
        <el-form-item label="标签：" prop="tags">
          <el-input v-model="list.model.tags" clearable />
        </el-form-item>
        <el-form-item label="摘要：" prop="abstract">
          <el-input v-model="list.model.abstract" clearable />
        </el-form-item>
      </template>

      <!--按钮-->
      <template v-slot:querybar-buttons>
        <nm-button-has :options="buttons.add" @click="add" />
      </template>

      <!--自定义列-->
      <!-- <template v-slot:col-name="{row}">
        <nm-button :text="row.name" type="text" />
      </template> -->

      <!--操作列-->
      <template v-slot:col-operation="{ row }">
        <nm-button v-bind="buttons.edit" @click="edit(row)" />
        <nm-button-delete v-bind="buttons.del" :id="row.id" :action="removeAction" @success="refresh" />
      </template>
    </nm-list>

    <save-page :id="curr.id" :visible.sync="dialog.save" @success="refresh" />
  </nm-container>
</template>
<script>
import { mixins } from 'netmodular-ui'
import page from './page'
import cols from './cols'
import SavePage from '../components/save'

const api = $api.forum.question

export default {
  name: page.name,
  mixins: [mixins.list],
  components: { SavePage },
  data() {
    return {
      list: {
        title: page.title,
        cols,
        action: api.query,
        model: {
          /** 标题 */
          title: '',
          /** 分类编号 */
          categoryId: '',
          /** 标签 */
          tags: '',
          /** 摘要 */
          abstract: ''
        }
      },
      removeAction: api.remove,
      buttons: page.buttons
    }
  }
}
</script>
