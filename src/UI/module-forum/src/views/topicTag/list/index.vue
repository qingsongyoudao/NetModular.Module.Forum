<template>
  <nm-list ref="list" v-bind="list">
    <!--查询条件-->
    <template v-slot:querybar>
      <el-form-item label="主题ID：" prop="topicId">
        <el-input v-model="list.model.topicId" clearable />
      </el-form-item>
      <el-form-item label="标签ID：" prop="tagId">
        <el-input v-model="list.model.tagId" clearable />
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
    <save-page :id="curr.id" :visible.sync="dialog.save" @success="refresh" />
  </nm-list>
</template>
<script>
import { mixins } from 'netmodular-ui'
import page from '../index/page'
import cols from './cols'
import SavePage from '../components/save'

const api = $api.forum.topicTag

export default {
  name: page.name,
  mixins: [mixins.list],
  components: { SavePage },
  data() {
    return {
      list: {
        title: page.title,
        cols,
        operationWidth: '150px',
        action: this.query,
        noReset: true,
        noHeader: true,
        noFooter: true,
        noQuerybar: this.readonly_,
        noOperation: this.readonly_,
        model: {
          /** 主题ID */
          topicId: '',
          /** 标签ID */
          tagId: ''
        }
      },
      removeAction: api.remove,
      buttons: page.buttons
    }
  },
  props: {
    topicId: Number,
    readonly_: Boolean
  },
  methods: {
    query() {
      this.list.model.topicId = this.topicId
      return api.query({ topicId: this.topicId })
    }
  },
  watch: {
    readonly_: {
      immediate: true,
      handler(val) {
        this.list.noQuerybar = val
        this.list.noOperation = val
      }
    }
  }
}
</script>
