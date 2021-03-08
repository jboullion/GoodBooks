<template>
  <router-link :to="`/books/${book.id}`" class="book">
   <v-list-item>
      <v-list-item-avatar>
        <v-img
          :src="`https://picsum.photos/seed/${book.title}/50`"
        >
        </v-img>
      </v-list-item-avatar>

      <v-list-item-content>
        <v-list-item-title v-text="book.title"></v-list-item-title>

        <v-list-item-subtitle class="text--primary" v-text="book.author"></v-list-item-subtitle>
        <v-list-item-subtitle>{{ book.createdOn | humanize }}</v-list-item-subtitle>
      </v-list-item-content>

      <v-list-item-action>
        <v-btn icon
          @click.prevent="deleteBook(book.id)">
          <v-icon color="red lighten-1">mdi-delete</v-icon>
        </v-btn>
      </v-list-item-action>
    </v-list-item>

    <v-divider inset></v-divider>
  </router-link>
</template>

<script lang="ts">
  import BookService from "@/services/book-service";
  import IBook from '@/types/Book';
  import { Component, Prop, Vue } from 'vue-property-decorator';

  const bookService = new BookService();

  @Component({
    name: 'BookListItem',
    components: {}
  })

  export default class BookListItem extends Vue {
    active = false;

    @Prop({ required: true })
    book!: IBook;

    async deleteBook(bookId: number){

      await bookService.deleteBook(bookId)
        .then(() => {
          //console.log(res);
          this.$emit('reloadBooks');
        })
        .catch(err => console.error(err));

    }

  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
  .v-card__text {
    padding-bottom: 50px;
  }
  
  .v-card__actions {
    position: absolute;
    bottom: 0;
  }

  .book {
    display: block;
    transition: background-color 0.2s;
    text-decoration: none;
  }
  .book:hover {
    background-color:#f6f6f6;
  }
</style>
