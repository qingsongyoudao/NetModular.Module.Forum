<template>
  <div v-if="disabled == false">
    <quill-editor ref="myTextEditor" v-model="value" :options="editorOption" @blur="onEditorBlur($event)"> </quill-editor>
  </div>
  <div class="ql-editor" v-else v-html="content"></div>
</template>
<script>
export default {
  name: 'myEditor',
  props: {
    value: {
      type: String,
      default: '请输入内容'
    },
    disabled: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      editorOption: {
        modules: {
          toolbar: [
            ['bold', 'italic', 'underline', 'strike'],
            ['blockquote', 'code-block'],
            [{ header: 1 }, { header: 2 }],
            [{ list: 'ordered' }, { list: 'bullet' }],
            [{ script: 'sub' }, { script: 'super' }],
            [{ indent: '-1' }, { indent: '+1' }],
            [{ direction: 'rtl' }],
            [{ size: ['small', false, 'large', 'huge'] }],
            [{ header: [1, 2, 3, 4, 5, 6, false] }],
            [{ font: [] }],
            [{ color: [] }, { background: [] }],
            [{ align: [] }],
            ['clean'],
            ['link', 'image', 'video']
          ],
          history: {
            delay: 1000,
            maxStack: 50,
            userOnly: false
          },
          imageDrop: true,
          imageResize: {
            displayStyles: {
              backgroundColor: 'black',
              border: 'none',
              color: 'white'
            },
            modules: ['Resize', 'DisplaySize', 'Toolbar']
          }
        }
      }
    }
  },
  methods: {
    onEditorBlur() {
      // console.log(this.content)
    }
  }
}
</script>

<style>
.ql-editor {
  min-height: 300px;
}
</style>
