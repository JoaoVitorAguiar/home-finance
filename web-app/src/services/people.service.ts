import { api } from "@/services/api"
import type { Person } from "@/types/person"
import type { CreatePersonInput } from "@/types/person"



export class PeopleService {
    static async getAll(): Promise<Person[]> {
        const { data } = await api.get<Person[]>("/persons")
        return data
    }

    static async create(input: CreatePersonInput): Promise<number> {
        const { data } = await api.post<{ id: number }>("/persons", input)
        return data.id
    }

    static async delete(id: number): Promise<void> {
        await api.delete(`/persons/${id}`)
    }
}
