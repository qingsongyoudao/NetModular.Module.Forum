<template>
  <nm-container>
    <nm-list ref="list" v-bind="list">
      <!--查询条件-->
      <template v-slot:querybar>
        <el-form-item label="内容/IP：" prop="content">
          <el-input v-model="list.model.content" clearable />
        </el-form-item>
      </template>

      <template v-slot:querybar-advanced>
        <el-row>
          <el-col :span="10" :offset="1">
            <el-form-item label="主题ID：" prop="topicId">
              <el-input v-model="list.model.topicId" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="10" :offset="1">
            <el-form-item label="用户编号：" prop="userId">
              <el-input v-model="list.model.userId" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="10" :offset="1">
            <el-form-item label="回复人ID：" prop="to">
              <el-input v-model="list.model.to" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="10" :offset="1">
            <el-form-item label="回复内容：" prop="content">
              <el-input v-model="list.model.content" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="10" :offset="1">
            <el-form-item label="回复时间：" prop="createdTime">
              <el-input v-model="list.model.createdTime" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="10" :offset="1">
            <el-form-item label="创建IP：" prop="createdIP">
              <el-input v-model="list.model.createdIP" clearable />
            </el-form-item>
          </el-col>
        </el-row>
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

const api = $api.forum.comment

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
          /** 主题ID */
          topicId: '',
          /** 用户编号 */
          userId: '',
          /** 回复人ID */
          to: '',
          /** 回复内容 */
          content: '',
          /** 赞数 */
          upCount: '',
          /** 踩数 */
          downCount: '',
          /** 喜欢数 */
          likeCount: '',
          /** 回复时间 */
          createdTime: '',
          /** 创建IP */
          createdIP: ''
        },
        advanced: {
          enabled: true,
          width: '800px'
        }
      },
      removeAction: api.remove,
      buttons: page.buttons
    }
  }
}
</script>
