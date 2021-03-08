<template>
  <v-container>
    <h1 class="mb-5">Add Book</h1>
    <v-alert
      v-if="successMessage"
      border="left"
      type="success"
      dismissible
    >{{ successMessage }}</v-alert>
		<v-form
      ref="form"
      v-model="valid"
      lazy-validation
    >
      <v-text-field
        v-model="book.title"
        label="Title"
        required
      ></v-text-field>

      <v-text-field
        v-model="book.author"
        label="Author"
        required
      ></v-text-field>

      <v-btn
        :disabled="isButtonDisabled"
        color="success"
        class="mr-4"
        @click="submitBook"
      >
        Submit
      </v-btn>

      <v-btn
        color="error"
        class="mr-4"
        @click="reset"
      >
        Reset Form
      </v-btn>
    </v-form>

  </v-container>
</template>

<script lang="ts">
  import BookService from "@/services/book-service";
  import IBook from '@/types/Book';
  import { Component, Vue } from 'vue-property-decorator';

  const bookService = new BookService();

  @Component({
    name: 'AddBook',
    components: { }
  })
  export default class AddBook extends Vue {
    // data
    book: IBook = {
      title: '',
      author: ''
    };
   
    valid = false;
    successMessage = '';

    reset () {
      //this.$refs.form.reset();
      this.book.title = '';
      this.book.author = '';
    }

    get isButtonDisabled(){
      return this.book.title === "" 
      || this.book.author === "";
    }

    submitBook(){
      const bookTitle = this.book.title;
      bookService.addBook(this.book)
        .then(() => {
          //console.log(res);
          this.reset();
          this.successMessage = '"'+bookTitle+'" added to book list!';
          // setTimeout(()=>{
          //   this.successMessage = '';
          // }, 5000)
        })
        .catch(err => console.error(err));
        
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
