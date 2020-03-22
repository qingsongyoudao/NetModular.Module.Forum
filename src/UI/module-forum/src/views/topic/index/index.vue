<template>
  <nm-container>
    <nm-list ref="list" v-bind="list" :show-overflow-tooltip="true">
      <!--查询条件-->
      <template v-slot:querybar>
        <el-form-item label="标题：" prop="title">
          <el-input v-model="list.model.title" clearable />
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
            <el-form-item label="分类ID：" prop="categoryId">
              <el-input v-model="list.model.categoryId" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="10" :offset="1">
            <el-form-item label="内容：" prop="content">
              <el-input v-model="list.model.content" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="10" :offset="1">
            <el-form-item label="创建时间：" prop="createdTime">
              <el-input v-model="list.model.createdTime" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="10" :offset="1">
            <el-form-item label="最后回复时间：" prop="lastReplyTime">
              <el-input v-model="list.model.lastReplyTime" clearable />
            </el-form-item>
          </el-col>
          <el-col :span="10" :offset="1">
            <el-form-item label="发布IP：" prop="createdIP">
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

const api = $api.forum.topic

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
          /** 用户ID */
          userId: '',
          /** 标题 */
          title: '',
          /** 分类ID */
          categoryId: '',
          /** 内容 */
          content: '',
          /** 预览数 */
          viewCount: '',
          /** 赞数 */
          upCount: '',
          /** 踩数 */
          downCount: '',
          /** 喜欢数 */
          likeCount: '',
          /** 评论数 */
          commentCount: '',
          /** 创建时间 */
          createdTime: '',
          /** 最后回复时间 */
          lastReplyTime: '',
          /** 发布IP */
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
