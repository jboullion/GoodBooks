import axios from 'axios';
import IBook from "@/types/Book"

export default class BookService {
	API_URL = process.env.VUE_APP_API_URL;

	public async getAllBooks(): Promise<IBook[]> {
		const result = await axios.get(`${this.API_URL}/books/`);
		return result.data;
	}

	public async addBook(book: IBook) {
		const result = await axios.post(`${this.API_URL}/books/`, book);
		return result.data;
	}

	public async deleteBook(bookId: number) {
		const result = await axios.delete(`${this.API_URL}/books/${bookId}`);
		return result.data;
	}
}